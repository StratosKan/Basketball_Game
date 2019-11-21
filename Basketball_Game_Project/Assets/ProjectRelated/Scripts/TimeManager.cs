using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public TextMesh timerText;
    public TextMesh timerText2;

    public GameObject timeStartSound;
    public GameObject timeEndSound;

    public GameObject timeEndText;
    public float timeLeft = 23f; //Welcome to the family (i use this phrase for variables i use in other scripts often)

    LoadSceneOnClick loadSceneOnClick;

    void Start()
    {
        timeStartSound.SetActive(true);
        timeEndSound.SetActive(false);
        loadSceneOnClick = this.GetComponent<LoadSceneOnClick>();  //Load scene on click is located on the time manager.
    }

    void FixedUpdate()
    {
        timeLeft -= Time.fixedDeltaTime;
        
        if (timeLeft > 0)
        {
            timeStartSound.SetActive(false);
            timeEndSound.SetActive(false);
            timeEndText.SetActive(false);
            timerText.text = "Time:" + timeLeft.ToString("f1");                           //Tells the timerTextMesh to show the time
            timerText2.text = "Time:" + timeLeft.ToString("f1");         
        }  
        if (timeLeft <= 0)
        {
            //timeEndText.text = "Time's Up! Press <E> to go to the next Level";  //jim edit changed to gameobject!

            timeEndText.SetActive(true);  //TODO: Maybe add the E button part to another text.
            timeEndSound.SetActive(true);
            
            //Scene activeScene = SceneManager.GetActiveScene();                   //Gets the currently active scene.

            if (Input.GetKeyDown(KeyCode.E))                                     
            {
                loadSceneOnClick.LoadNextSceneThroughIndex();                     //Loads the next scene.
                //BACKUP PLAN IN CASE BUILD INDEX LOADER FAILS
                //
                //switch (activeScene.name)                                        //And a switch case construct to navigate from one scene to another. Fixed. Can be done by index but not required for this scale.
                //{
                //    case "Basketball_tutorial":
                //        SceneManager.LoadScene("Basketball_outdoor_concrete");
                //        break;
                //    case "Basketball_outdoor_concrete" :
                //        SceneManager.LoadScene("Basketball_indoor_wood");
                //        break;
                //    case "Basketball_indoor_wood":
                //        SceneManager.LoadScene("Basketball_outdoor_tartan");
                //        break;
                //    case "Basketball_outdoor_tartan":
                //        SceneManager.LoadScene("Basketball_indoor_wood_crowd");
                //        break;
                //    case "Basketball_indoor_wood_crowd":
                //        SceneManager.LoadScene("Basketball_outdoor_tartan_crowd");
                //        break;
                //    case "Basketball_outdoor_tartan_crowd": //if scoreFull (singleton) >=15 load ultimate level else menu
                //        SceneManager.LoadScene("BBallMainMenu");
                //        break;
                //}
            }
        }
        //Debug.Log(timeLeft); //works
    }
}
