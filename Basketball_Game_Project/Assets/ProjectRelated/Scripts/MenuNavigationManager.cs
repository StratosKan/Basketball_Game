using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuNavigationManager : MonoBehaviour
{
    public EventSystem eventSystem;       //Reference to the event system.

    public GameObject selectedObject;

    public bool buttonSelected;        

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))                              //Closes App
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)  //Detects any vertical input...
        {
            eventSystem.SetSelectedGameObject(selectedObject);            //...and tells the event system to select it
            buttonSelected = true;
        }

	}
    private void OnDisable()
    {
        buttonSelected = false;
    }

    //public void ButtonClicked()
    //{
    //    Debug.Log("Button Clicked");
    //}
}
