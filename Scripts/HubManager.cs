using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    public static HubManager Instance { set; get; }

    // HubObject
    public Button backButton;
    private HubObject currentHubObject;
    private bool transistionFrame = false;

    // Camera
    public Transform defaultCameraWaypoint;
    private Transform camTransform;
    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    private void Start()
    {
        backButton.interactable = false;
        camTransform = Camera.main.transform;
        SetDesiredWaypoint(defaultCameraWaypoint);
    }

    private void Update()
    {
        MoveCamera();

        if (Input.GetMouseButtonUp(0) && !transistionFrame)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 75.0f,LayerMask.GetMask("HubObject")))
            {
                Debug.Log(hit.transform.name);
                currentHubObject = hit.transform.GetComponent<HubObject>();
                currentHubObject.FadeMenu(true);
                SetDesiredWaypoint(currentHubObject.waypoint);
                backButton.interactable = true;
            }
        }
        transistionFrame = false;
    }

    private void MoveCamera()
    {
        camTransform.position = Vector3.Lerp(camTransform.position, desiredPosition, Time.deltaTime);
        camTransform.rotation = Quaternion.Lerp(camTransform.rotation, desiredRotation, Time.deltaTime);
    }
    public void SetDesiredWaypoint(Transform waypoint)
    {
        desiredPosition = waypoint.position;
        desiredRotation = waypoint.rotation;
    }

    public void DropMenu()
    {
        if (currentHubObject == null)
        {
            return;
        }

        transistionFrame = true;
        currentHubObject.FadeMenu(false);
        currentHubObject = null;
        backButton.interactable = false;
        SetDesiredWaypoint(defaultCameraWaypoint);
    }

    public void Kitchen3DModelsButton()
    {
        SceneManager.LoadScene("Kitchen3DModels");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main");
    }
}
