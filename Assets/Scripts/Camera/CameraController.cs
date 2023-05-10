using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
//#if UNITY_IOS || UNITY_ANDROID
    public Camera Camera;
    public bool Rotate;
    protected Plane Plane;
    //public float inertia = 0.2f;
    public Vector3 velocity = Vector3.zero;

    //bounds
    int MIN_X = 0;
    int MAX_X = 100;
    int MIN_Y = 2;
    int MAX_Y = 10;
    int MIN_Z = 0;
    int MAX_Z = 100;

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


        //Scroll
        if (Input.touchCount >= 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Delta1 = PlanePositionDelta(Input.GetTouch(0));

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Camera.transform.Translate(Delta1, Space.World);
                Camera.transform.position = new Vector3(Mathf.Clamp(Camera.transform.position.x, MIN_X, MAX_X), Camera.transform.position.y, Mathf.Clamp(Camera.transform.position.z, MIN_Z, MAX_Z));
            }
        }

        //Pinch
        if (Input.touchCount >= 2 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
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
//#endif

}
