using UnityEngine;

public class BallOutScript : MonoBehaviour
{
    public static bool ballOut = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BBall" && BallInScript.ballIn)
        {
            ballOut = true;
        }
        else
        {
            BallInScript.ballIn = false;
            ballOut = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "BBall")
        {
            if (ballOut == false)
            {
                BallInScript.ballIn = false;
            }
        }
    }
}
