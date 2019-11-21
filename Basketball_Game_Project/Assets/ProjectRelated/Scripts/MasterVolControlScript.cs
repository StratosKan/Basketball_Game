using UnityEngine;

public class MasterVolControlScript : MonoBehaviour
{
    //Figured out how to do it, instead of a float - inspector value put it on the 
    //options slider.


    [Range(0f, 10f)]
    public float volume = 5f;

    FMOD.Studio.Bus sfxBus;


    void Start()
    {
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/");      
    }

	void FixedUpdate ()
    {
        sfxBus.setVolume(volume);
    }
}
