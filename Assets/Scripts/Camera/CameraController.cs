using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    //#if UNITY_IOS || UNITY_ANDROID
    //bounds
    int MIN_X = 0;
    int MAX_X = 100;
    int MIN_Y = 2;
    int MAX_Y = 11;
    int MIN_Z = 0;
    int MAX_Z = 100;

    public Camera Camera;
    public bool Rotate;
    protected Plane Plane;

    public float movementSpeed = 5f;
    public float damping = 0.1f;
    public float stopThreshold = 0.01f; // Distance threshold to stop camera movement
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    private bool isMoving = false;

    private Vector3 defaultPos = new Vector3(55, 11, 30);
    private Quaternion defaultRot = new Quaternion(45, 0, 0, 0);

    private Vector3 position;

    float duration;

    private void Awake()
    {
        if (Camera == null)
            Camera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount >= 1)
            Plane.SetNormalAndPosition(transform.up, transform.position);

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        if (!IsPointerOverUI())
        {
            //Scroll
            if (Input.touchCount >= 1)
            {
                Delta1 = PlanePositionDelta(Input.GetTouch(0));

                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    //isMoving = true;
                    //targetPosition += Delta1 * movementSpeed * Time.deltaTime;
                    Camera.transform.Translate(Delta1, Space.World);
                    Camera.transform.position = new Vector3(Mathf.Clamp(Camera.transform.position.x, MIN_X, MAX_X), Camera.transform.position.y, Mathf.Clamp(Camera.transform.position.z, MIN_Z, MAX_Z));
                }
            }

            //Pinch
            if (Input.touchCount >= 2)
            {
                var pos1 = PlanePosition(Input.GetTouch(0).position);
                var pos2 = PlanePosition(Input.GetTouch(1).position);
                var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
                var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

                //calc zoom
                var zoom = Vector3.Distance(pos1, pos2) /
                           Vector3.Distance(pos1b, pos2b);

                //edge case
                if (zoom == 0 || zoom > 10)
                    return;

                //Move cam amount the mid ray
                Camera.transform.position = Vector3.LerpUnclamped(pos1, Camera.transform.position, 1 / zoom);
                Camera.transform.position = new Vector3(Camera.transform.position.x, Mathf.Clamp(Camera.transform.position.y, MIN_Y, MAX_Y), Camera.transform.position.z);

                if (Rotate && pos2b != pos2)
                    Camera.transform.RotateAround(pos1, Plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, Plane.normal));
            }
        }

    }

    //void LateUpdate()
    //{
    //    if (isMoving)
    //    {
    //        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);

    //        // Calculate the delta movement
    //        Vector3 deltaMovement = newPosition - transform.position;

    //        // Translate the camera using the delta movement
    //        Camera.transform.Translate(deltaMovement, Space.World);

    //        // Clamp the camera position within the specified bounds
    //        //Vector3 clampedPosition = new Vector3(Mathf.Clamp(transform.position.x, MIN_X, MAX_X), transform.position.y, Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));
    //        //Camera.transform.position = clampedPosition;
    //        Camera.transform.position = new Vector3(Mathf.Clamp(Camera.transform.position.x, MIN_X, MAX_X), Camera.transform.position.y, Mathf.Clamp(Camera.transform.position.z, MIN_Z, MAX_Z));

    //        // Check if the camera is close enough to the target
    //        if (Vector3.Distance(transform.position, targetPosition) < stopThreshold)
    //        {
    //            isMoving = false; // Stop updating target position
    //        }
    //    }
    //}

    protected Vector3 PlanePositionDelta(Touch touch)
    {
        //not moved
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        //delta
        var rayBefore = Camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = Camera.ScreenPointToRay(touch.position);
        if (Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        //not on plane
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        //position
        var rayNow = Camera.ScreenPointToRay(screenPos);
        if (Plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    public IEnumerator OnBuildModeEnter()
    {
        duration = 0.75f;
        if (duration >= 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                Camera.transform.position = Vector3.MoveTowards(Camera.transform.position,
                    new Vector3(Camera.transform.position.x, 15, Camera.transform.position.z),
                    progress);
                Camera.transform.rotation = Quaternion.Slerp(Camera.transform.rotation, Quaternion.Euler(90, 0, 0), progress);
                yield return null;
            }
        }
        Camera.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public IEnumerator OnBuildModeExit()
    {
        duration = 0.75f;
        if (duration >= 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                // progress will equal 0 at startTime, 1 at endTime.
                Camera.transform.position = Vector3.MoveTowards(Camera.transform.position,
                    new Vector3(Camera.transform.position.x, 11, Camera.transform.position.z),
                    progress);
                Camera.transform.rotation = Quaternion.Slerp(Camera.transform.rotation, Quaternion.Euler(45, 0, 0), progress);
                yield return null;
            }
        }
        Camera.transform.rotation = Quaternion.Euler(45, 0, 0);
    }

    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
    //#endif

}
