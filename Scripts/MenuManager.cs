using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Fade Animations
    public GameObject uiRoot;
    private CanvasGroup uiRootGroup;
    private float fadeTransition;
    private bool menuAvaible = false;
    private bool fadeInTransition = false;
    private bool menuPoping = true;
    private float iddleTimeToFade = 5.0f;
    private float lastTouchTime;


    // Camera Fields
    private Transform camTransform;
    private Vector3 offset;
    private float transition = 0.0f;
    private float cameraSpeed = 20.5f;

    private void Start()
    {
        camTransform = Camera.main.transform;
        offset = CalculateCameraOffset();

        uiRootGroup = uiRoot.GetComponent<CanvasGroup>();
        uiRootGroup.alpha = 0;
        uiRootGroup.interactable = false;
        fadeTransition = 0.0f;

    }

    private void Update()
    {
        MoveCamera();
        UpdateFade();

        if (Input.GetMouseButtonDown(0))
        {
            OnTouch();
        }
    }

    private void OnTouch()
    {
        lastTouchTime = Time.time;
        uiRootGroup.interactable = true;
        fadeInTransition = true;
        menuAvaible = true;
        menuPoping = true;
        fadeTransition = Mathf.Clamp(fadeTransition, 0, 1);
    }

    private void UpdateFade()
    {
        if (Time.time - lastTouchTime > iddleTimeToFade)
        {
            fadeInTransition = true;
            menuPoping = false;
            menuAvaible = false;
            uiRootGroup.interactable = false;
        }

        if (!fadeInTransition)
        {
            return;
        }

        fadeTransition += (menuPoping) ? Time.deltaTime : -Time.deltaTime * 0.25f;
        uiRootGroup.alpha = fadeTransition;

        if (fadeTransition > 1 || fadeTransition < 0)
        {
            fadeInTransition = false;
        }
    }

    public void ToStart()
    {
        if (menuAvaible && !fadeInTransition)
        {
            SceneManager.LoadScene("Hub");
        }
        
    }

    public void ZlewozmywakiButton()
    {
        Debug.Log("Zlewy");
        SceneManager.LoadScene("Kitchen3DModels");
    }

    public void UmywalkiButton()
    {
        Debug.Log("Umywalki");
    }

    public void BrodzikiButton()
    {
        Debug.Log("Brodziki");
    }

    public void WannyButton()
    {
        Debug.Log("Wanny");
    }



    private Vector3 CalculateCameraOffset()
    {
        Vector3 r = Vector3.zero;
        r.x = 0f;
        r.y = 2.45f;
        r.z = -6.8f;
        return r;
    }
    private void MoveCamera()
    {
        float y = Mathf.Sin(Time.time) * 0.25f;
        transition += Time.deltaTime * cameraSpeed;
        Vector3 desiredPos = offset + (Vector3.up *y);
        Quaternion orientation = Quaternion.Euler(0, transition, 0);
        camTransform.position = orientation * desiredPos;
        camTransform.LookAt(Vector3.up * camTransform.position.y);
    }
}
