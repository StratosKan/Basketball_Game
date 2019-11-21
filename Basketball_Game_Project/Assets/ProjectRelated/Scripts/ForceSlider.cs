using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ForceSlider : MonoBehaviour
{


    private ShootingScript shootingScript;                                  //Reference to shooting script.
    private Slider slider;                                                  //Reference to the slider on this object.

    private void Start()
    {
        shootingScript = GameObject.Find("ThrowingPoint").GetComponent<ShootingScript>(); //.Find is slow, but it's fine in start.
        slider = this.GetComponent<Slider>();                                                        
    }
    void Update()
    {
        slider.value = shootingScript.finalForce;                                         //Aiming force == slider value
    }
    
}