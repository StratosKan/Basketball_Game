using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject HoopClose;
    public GameObject HoopMedium;
    public GameObject HoopFar;

    private TimeManager timeManagerScript;

    int points = 0;

    void Start()
    {
        timeManagerScript = GameObject.Find("TimeManager").GetComponent<TimeManager>();  //Assigns the Time Manager script to the variable.
    }

	void FixedUpdate ()
    {
        if (TutorialColliderScript.score >= 0 && TutorialColliderScript.score <= 2 && timeManagerScript.timeLeft <= 20f)
        {
            timeManagerScript.timeLeft = 20f; // Cheatsy way of adding infinite time without changing alot of scripts just for the tutorial
        }
        else if (TutorialColliderScript.score == 3)
        {
            timeManagerScript.timeLeft = 0f;
        }


        if (!HoopClose.activeSelf && points != ScoreManager.scoreCount)
        {
            points = ScoreManager.scoreCount;
        }
        if (!HoopMedium.activeSelf && points != ScoreManager.scoreCount)
        {
            points = ScoreManager.scoreCount;
        }
        if (!HoopFar.activeSelf && points != ScoreManager.scoreCount)
        {
            points = ScoreManager.scoreCount;
        }
    }
}