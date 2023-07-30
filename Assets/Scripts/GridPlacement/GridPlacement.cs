using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridPlacement : MonoBehaviour
{
    public Action OnTap, OnExit;
    [SerializeField] private CameraController cameraController;

    [SerializeField] private ObjectsDB database;
    private int selectedIndex = -1;

    private GameObject gridVisualization;
    [SerializeField] private Grid grid;

    private void Start()
    {
        StopPlacement();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("TOUCH DETECTED");
                OnTap?.Invoke();

            }
            //if (touch.phase == TouchPhase.Ended)
            //{
            //    OnExit?.Invoke();
            //}
        }
    }

    public Vector3 GetTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        return touch.position;
    }

    public void StartPlacement(int id)
    {
        selectedIndex = database.objectsData.FindIndex(data => data.ID == id);
        if(selectedIndex < 0)
        {
            Debug.Log("No id found");
            return;
        }
        OnTap += PlacementStructure;
        OnExit += StopPlacement;
    }

    private void PlacementStructure()
    {
        Debug.Log("Start touch");
        if (cameraController.IsPointerOverUI())
        {
            return;
        }
        Vector3 touchPosition = Vector3.zero;
        touchPosition = PlanePositionDelta();
        Vector3Int gridPos = grid.WorldToCell(touchPosition);
        GameObject newObj = Instantiate(database.objectsData[selectedIndex].prefab);
        newObj.transform.position = gridPos;
        Debug.Log(touchPosition + " " + gridPos);
    }

    protected Vector3 PlanePositionDelta()
    {
        Touch touch = Input.GetTouch(0);

        Ray ray = cameraController.Camera.ScreenPointToRay(touch.position);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 touchWorldPosition = ray.GetPoint(distance);

            float snappedX = Mathf.RoundToInt(touchWorldPosition.x / 2.0f) * 2.0f;
            float snappedZ = Mathf.RoundToInt(touchWorldPosition.z / 2.0f) * 2.0f;
            return new Vector3(snappedX, 0, snappedZ);
            //return new Vector3(Mathf.RoundToInt(ray.GetPoint(distance).x), 0, Mathf.RoundToInt(ray.GetPoint(distance).z));
            //Vector3 snappedPosition = new Vector3(Mathf.RoundToInt(touchWorldPosition.x), 0, Mathf.RoundToInt(touchWorldPosition.z));
        }
        return Vector3.zero;
    }

    private void StopPlacement()
    {
        selectedIndex = -1;
        OnTap -= PlacementStructure; 
        OnExit -= StopPlacement;
    }
    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
}
