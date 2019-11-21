using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int scoreCount; //Welcome to the family
    public TextMesh scoreText;
    public TextMesh scoreText2;

    private TimeManager timeManagerScript;

    void Awake()
    {
        scoreCount = 0;
        timeManagerScript = GameObject.Find("TimeManager").GetComponent<TimeManager>();  //Assigns the Time Manager script to the variable.
    }

    void FixedUpdate()
    {
        //TODO: Singleton to move to next scene
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene.buildIndex == 1) //The tutorial scene is the one with build index = 1 EXLUSIVE CASE FOR TUTORIAL
        {
            scoreText.text = "Score: " + scoreCount;
            scoreText2.text = "Score: " + scoreCount;
        }
        else
        {
            if (timeManagerScript.timeLeft > 0)                     //Checks if there is time remaining...
            {
                scoreText.text = "Score: " + scoreCount;             //...and assigns the score to the 3D text object on scene.
                scoreText2.text = "Score: " + scoreCount;
            }
        }
    }
}
