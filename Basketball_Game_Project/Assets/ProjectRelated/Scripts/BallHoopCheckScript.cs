using UnityEngine;

public class BallHoopCheckScript : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        BallInScript.ballIn = false; //EXTRA SAFETY
        BallOutScript.ballOut = false;
    }
}
