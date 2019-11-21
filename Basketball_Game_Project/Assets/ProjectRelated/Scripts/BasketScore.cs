using UnityEngine;

public class BasketScore : MonoBehaviour
{
    void FixedUpdate()
    {
        if (BallInScript.ballIn && BallOutScript.ballOut)
        {
            ScoreManager.scoreCount++;
            BallInScript.ballIn = false;
            BallOutScript.ballOut = false;
        }
    }
}