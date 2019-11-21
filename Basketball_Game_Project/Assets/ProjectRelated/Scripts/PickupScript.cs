using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public static bool pickedUp;


    void OnCollisionEnter(Collision other)
    {
        if (ShootingScript.toPickup)
        {
            if (other.gameObject.tag == "BBall")
            {
                pickedUp = true;
            }
        }
    }
}
