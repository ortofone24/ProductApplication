using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HubObject : MonoBehaviour
{
    public Transform waypoint;
    public GameObject menu;

    private CanvasGroup cGroup;
    private float transition = 0.0f;
    private bool inTransition = false;
    private bool isPoping = true;  //if we showing the menu

    private void Start()
    {
        cGroup = menu.GetComponent<CanvasGroup>();
        cGroup.alpha = 0;
        cGroup.interactable = false;
    }

    private void Update()
    {
        if (transition < 0 || transition > 1)
        {
            inTransition = false;
        }

        if (!inTransition)
        {
            return;
        }

        transition += (isPoping) ? Time.deltaTime : -Time.deltaTime;
        cGroup.alpha = transition;
    }

    public void FadeMenu(bool show)
    {
        isPoping = show;
        cGroup.interactable = show;
        inTransition = true;
        transition = Mathf.Clamp(transition, 0, 1);
    }
}
