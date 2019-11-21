using UnityEngine;

public class CrowdControllerScript : MonoBehaviour
{
    public GameObject Crowd_Chearing;
    public GameObject Crowd_Booing;

    int score = 0;
    float timer = 1f;
    bool ballDespawn = false;

    void Start()
    {
        score = ScoreManager.scoreCount;
    }

    void FixedUpdate()
    {
        Timer();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BBall")
        {
            if (ballDespawn)
            {
                if (score != ScoreManager.scoreCount)
                {
                    Crowd_Chearing.SetActive(true);
                    score = ScoreManager.scoreCount;
                    timer = 1f;
                }
                else
                {
                    Crowd_Booing.SetActive(true);
                    timer = 1f;
                }
                Crowd_Chearing.SetActive(false);
                Crowd_Booing.SetActive(false);
            }       
            BallInScript.ballIn = false; //EXTRA SAFETY
            BallOutScript.ballOut = false;
        }
    }

    void Timer()
    {
        timer -= Time.fixedDeltaTime;
        if (timer < 0)
        {
            ballDespawn = true;
        }
        else
        {
            ballDespawn = false;
        }
    }
}