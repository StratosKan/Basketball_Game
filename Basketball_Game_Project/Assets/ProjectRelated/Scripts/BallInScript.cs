using UnityEngine;

public class BallInScript : MonoBehaviour
{
    public static bool ballIn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BBall" && !BallOutScript.ballOut)
        {
            ballIn = true;
        }
    } 
}