using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    float verticalMomentum;
    float horizontalMomentum;
    public bool isPlayerMoving = false;

    Rigidbody rb;

    Vector3 noMovement;

    private TimeManager timeManagerScript;

    void Start ()
    {
        timeManagerScript = GameObject.Find("TimeManager").GetComponent<TimeManager>();  //Assigns the Time Manager script to the variable.

        rb = GetComponent<Rigidbody>();

        noMovement = new Vector3(0, 0, 0);  //Empty Vector to check movement input.
	}
	
	void FixedUpdate ()
    {
        Movement();                          //Movement method. Runs on every frame.
	}


    Vector2 GetInput()
    {
        return new Vector2 
        {
            x = Input.GetAxis("Vertical") * movementSpeed,
            y = Input.GetAxis("Horizontal") * movementSpeed
        };
    }

    void Movement()
    {
        if (!ShootingScript.isAiming && timeManagerScript.timeLeft <=20f && timeManagerScript.timeLeft > 0f)
        {
            Vector3 momentum = new Vector3(GetInput().y, 0.0f, GetInput().x);  //Calls Input method to get movement input on x,y

            CheckMovement(momentum);

            momentum = transform.rotation * momentum;
            rb.velocity = momentum;
        }
        else if (!ShootingScript.isAiming && timeManagerScript.timeLeft <= 0f)
        {
            Vector3 momentum = new Vector3(0.0f, 0.0f, 0.0f);   //Makes player stand still
            CheckMovement(momentum);

            momentum = transform.rotation * momentum;
            rb.velocity = momentum;
        }
    }
     
    void CheckMovement(Vector3 momentum) //You want methods Jim, i give you methods.
    {
        if (momentum != noMovement)   //Having true on first bracket feels more optimal and responsive. Otherwise, use == and swap true/false.
        {
            isPlayerMoving = true;
        }
        else
        {
            isPlayerMoving = false;
        }
    }
}
