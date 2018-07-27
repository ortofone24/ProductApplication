using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelsSelection : MonoBehaviour
{
  
    public GameObject[] panels;
    
    public static ModelsSelection Instance { get; set; }
    
    public static int selection = 0; //default selection

    public List<GameObject> models = new List<GameObject>();

    private Camera main;
    
    private void Start()
    {
        Instance = this;
        
        foreach (GameObject go in models)
        {
            go.SetActive(false);
        }

        models[selection].SetActive(true);
        panels[1].SetActive(true);
        main = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            models[selection].SetActive(false);
            selection++;
            Debug.Log(selection);
            if (selection >= models.Count)
            {
                selection = 0;
            }
            models[selection].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            models[selection].SetActive(false);
            selection--;
            Debug.Log(selection);
            if (selection < 0)
            {
                selection = models.Count - 1;
            }
            models[selection].SetActive(true);
        }
    }


    #region Kitchens Button3D Click
    public void KitchensButtonClickOnIndex0()
    {
        main.fieldOfView = 60;
        panels[0].SetActive(false);
        models[selection].SetActive(false);
        models[0].SetActive(true);
        panels[1].SetActive(true);
        selection = 0;
    }

    public void KitchensButtonClickOnIndex1()
    {
        main.fieldOfView = 60;
        panels[0].SetActive(false);
        models[selection].SetActive(false);
        models[1].SetActive(true);
        panels[1].SetActive(true);
        selection = 1;
    }

    public void KitchensButtonClickOnIndex2()
    {
        main.fieldOfView = 60;
        panels[0].SetActive(false);
        models[selection].SetActive(false);
        models[2].SetActive(true);
        panels[1].SetActive(true);
        selection = 2;
    }

    public void KitchensButtonClickOnIndex3()
    {
        main.fieldOfView = 60;
        panels[0].SetActive(false);
        models[selection].SetActive(false);
        models[3].SetActive(true);
        panels[1].SetActive(true);
        selection = 3;
    }

    public void KitchensButtonClickOnIndex4()
    {
        main.fieldOfView = 60;
        panels[0].SetActive(false);
        models[selection].SetActive(false);
        models[4].SetActive(true);
        panels[1].SetActive(true);
        selection = 4;
    }
    #endregion

    #region Kitchens ButtonPDF Click
    public void KitchensButtonClickOnIndex0PDF()
    {
        models[selection].SetActive(false);
        panels[1].SetActive(false);
        panels[0].SetActive(true);
        selection = 0;
    }
    #endregion



    #region SwitchingColors

    public void SwitchColorBlack()
    {
        models[selection].GetComponent<Renderer>().material.color = Color.black;
        
    }

    public void SwitchColorWhite()
    {
        models[selection].GetComponent<Renderer>().material.color = Color.white;
    }

    public void SwitchColorGreen()
    {
        models[selection].GetComponent<Renderer>().material.color = Color.green;
    }

    public void SwitchColorYellow()
    {
        models[selection].GetComponent<Renderer>().material.color = Color.yellow;
    }
    #endregion

    public void BackButton()
    {
        SceneManager.LoadScene("Main");
    }
}
