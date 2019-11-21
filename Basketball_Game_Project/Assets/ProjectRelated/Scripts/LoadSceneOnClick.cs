using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

	public void MainMenuScene()
    {
        Time.timeScale = 1;                               //timeScale is for pause/unpause purposes.
        SceneManager.LoadScene("BBallMainMenu");
    }
    public void MainScene()                              //Prototype Scene.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Basketball_Prototype");        
    }
    public void WoodScene()                        //Full experience, no warmup.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("STAGE_1 (wood)");
    }
    public void TutorialScene()                        //Full experience.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("STAGE_0 (Tutorial)");
    }
    public void LoadByIndex(int sceneIndex)             //sceneIndex will be the build order on the final build.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitScene()
    {
#if UNITY_EDITOR                                           //If we are on Unity just stop playing...
        UnityEditor.EditorApplication.isPlaying = false;
#else                                                      //...if we are on build, close the app.
        Application.Quit();
#endif
    }
    public void RestartCurrentScene()
    {
        Time.timeScale = 1;
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void LoadNextSceneThroughIndex()
    {
        Time.timeScale = 1;
        int maxScenes = 16; // Change to the final build index length
        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene + 1;
        if (nextScene <= maxScenes)
        {
           SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);  //Maybe proper but who cares.
        }
        else if (nextScene > maxScenes)
        {
            MainMenuScene();                //Brings us back the menu.
        }
    }
}
