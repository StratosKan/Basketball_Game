using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DribblingOnMove : MonoBehaviour
{
    
    public float audioTimeFeet;          //Time between audio plays in movement.

    public float audioTimeDribble;       //Time between audio plays in dribble.

    private PlayerControllerScript playerController; //Reference to player controller script.

    public GameObject feet;                          //Reference to the position of player's feet, so we enable that object and FMOD plays audio.

    public GameObject dribbleSpot;                   //Reference to the position of dribble, so we enable that object and FMOD plays audio.  
                                                     
    public GameObject aimSpot;

    void Start ()
    {
        playerController = this.GetComponent<PlayerControllerScript>(); //We do this because script is on same object.

        audioTimeFeet = 0.8f;              //We reset this to 1.0f every time ball is instantiated and player is moving.

        audioTimeDribble = 2.4f;
    }

    void FixedUpdate()  //Fix3d Update Jim? Works i guess.  TODO: Check if its the correct way.
    {
        if (!ShootingScript.isAiming)    //Checks if player is aiming (with static bool).
        {
            aimSpot.SetActive(false);    //

            FeetSound();
            DribbleSound();
        }
        else
        {
            AimSound();
        }
    }

    void DribbleSound()  //TODO: Fix timer with audio designer.
    {
        if (playerController.isPlayerMoving && !ShootingScript.readyFlag)
        {
            dribbleSpot.SetActive(true);           //Enabling object plays audio.

            if (audioTimeDribble < 1.2f)           
            {
                dribbleSpot.SetActive(false);
                audioTimeDribble = 2.4f;
            }
            audioTimeDribble -= Time.fixedDeltaTime;
        }
        else
        {
            dribbleSpot.SetActive(false);
        }
    }
    void FeetSound()                        //Realistic feet sound with FMOD.
    {
        if (playerController.isPlayerMoving)
        {
            feet.SetActive(true);           //Enabling object plays audio.

            if (audioTimeFeet < 0.4f)           
            {
                feet.SetActive(false);
                audioTimeFeet = 0.8f;
            }
			audioTimeFeet -= Time.fixedDeltaTime;
        }
        else
        {
            feet.SetActive(false);
        }
    }
    void AimSound()
    {
        aimSpot.SetActive(true);
    }
    //public void SetMusicMixerVolume(float value)  //FMOD audio volume levels control 
    //{                                             //TODO: Set it up.
    //    float dbVolume = (value * 100f) – 80f;
    //    RuntimeManager.GetVCA(“vca:/ music”).setFaderLevel(value);
    //}
    //public void SetSFXMixerVolume(float value)
    //{
    //    float dbVolume = (value * 100f) – 80f;
    //    RuntimeManager.GetVCA(“vca:/ fx”).setFaderLevel(value);
    //}
}
