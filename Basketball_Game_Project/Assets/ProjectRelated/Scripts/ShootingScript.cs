using System.Collections;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("Infinite balls, DEBUG!")]
    public bool InfiniteThrows = false;

    public static bool toPickup = false;

    [Range(1f,100f)]
    public float forceToAddPerFrame = 50f;

    [Header("Time in seconds until the ball respawns")]
    public float timeUntilBallRespawn = 1f;

    [Header("Time in seconds until the ball despawns")]
    public float timeUntilBallDespawn = 3f;

    private GameObject BBallPrefab;

    GameObject BBall;
    Rigidbody BBall_rb;
    public GameObject Basketball_dummy;

    bool isCreated = false;

    public static bool isAiming = false;

    public static bool readyFlag = false;
    public float finalForce = 1f; //public for ForceSliderScript

    private TimeManager timeManagerScript;

    void Start()
    {
        timeManagerScript = GameObject.Find("TimeManager").GetComponent<TimeManager>();  //Assigns the Time Manager script to the variable.

        BBallPrefab = (GameObject)(Resources.Load("Basketball"));
    }

    void LateUpdate()
    {
        ThrowBall();
    }

    void ThrowBall()
    {
        if (!isCreated && timeManagerScript.timeLeft <= 20f)   //TODO:Method
        {
            if (InfiniteThrows)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    BBall = Instantiate(BBallPrefab, transform.position, transform.rotation);
                    BBall_rb = BBall.GetComponent<Rigidbody>();

                    ComponentEnabler();

                    BBall_rb.AddForce(transform.forward * 35f, ForceMode.Impulse);
                    finalForce = 1f;

                    isCreated = false;
                }
            } //Infinite throws DEBUG

            if (!InfiniteThrows)
            {
                if (Input.GetMouseButtonDown(0) && readyFlag == false && timeManagerScript.timeLeft > 0f)
                {
                    Basketball_dummy.SetActive(false);

                    isAiming = true;                  

                    BBall = Instantiate(BBallPrefab, transform.position, transform.rotation);
  
                    BBall_rb = BBall.GetComponent<Rigidbody>();                      //Simple reference so we apply physics.
                    BBall_rb.Sleep();
                    readyFlag = true;
                } //State 0
                else if (Input.GetMouseButton(0) && readyFlag == true)
                {
                    BBallFollower();
                    BBall_rb.Sleep();
                    finalForce += forceToAddPerFrame * Time.deltaTime; //added delta time for timing reasons with laggy scenes, to revert, remove Time.deltaTime and switch the multiplier to a range of 0.1f to 1f (was 0.7f)
                    if (finalForce >= 45f)
                    {
                        finalForce = 45f;
                    }
                } //State 1
                else if (Input.GetMouseButtonUp(0) && readyFlag == true)
                {
                    isAiming = false;

                    BBall_rb.WakeUp();

                    ComponentEnabler();

                    BBall_rb.AddForce(transform.forward * finalForce, ForceMode.Impulse); //Int cast for fewer shooting possibilities and better user experience.

                    finalForce = 1f;         //Resets force value.

                    isCreated = true;

                    StartCoroutine(TimeToPass(BBall));
                } // State 2
            } //Normal mode  
        }
        
    }

    void ComponentEnabler()
    {
        TrailRenderer BBall_tr = BBall.GetComponent<TrailRenderer>();              //Enables the trail renderer when we shoot, so we don't see a trail when we move with ball.
        BBall_tr.enabled = true;
        SphereCollider BBall_sphC = BBall.GetComponent<SphereCollider>();          //Enables the Collider when we shoot, so ball doesnt go to luna park.
        BBall_sphC.enabled = true;
    }
    
    void BBallFollower()
    {
        
        BBall.transform.position = gameObject.transform.position;
        BBall.transform.rotation = gameObject.transform.rotation;
        BBall_rb.Sleep();
    }


    public IEnumerator TimeToPass(GameObject BBall) //Starts a timer in seconds until the Bball is destroyed. Does not work if Infinite Throws is true!
    {
        yield return new WaitForSeconds(timeUntilBallRespawn); //Waits 3 (default) seconds and then...

        Destroy(BBall,timeUntilBallDespawn);                             //...destroys the ball 

        Basketball_dummy.SetActive(true);

        isCreated = false;                         //...and resets spawn.
        readyFlag = false;
    }
}