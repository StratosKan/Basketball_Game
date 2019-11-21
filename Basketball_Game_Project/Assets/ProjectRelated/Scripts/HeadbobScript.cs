using UnityEngine;

public class HeadbobScript : MonoBehaviour
{
    private float timer = 0.0f;
    public float bobbingSpeed = 0.3f;
    public float bobbingAmount = 0.035f;
    public float midpointY = 0.195f;
    public float midpointX = 0f;

    private TimeManager timeManagerScript;

    void Awake()
    {
        timeManagerScript = GameObject.Find("TimeManager").GetComponent<TimeManager>();  //Assigns the Time Manager script to the variable.
    }

    void FixedUpdate()
    {
        if (!ShootingScript.isAiming && timeManagerScript.timeLeft <= 20f && timeManagerScript.timeLeft >= 0f)
        {
            float waveslice = 0.0f;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 headpos = transform.localPosition;

            if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
            {
                timer = 0.0f;
            }
            else
            {
                waveslice = Mathf.Sin(timer);
                timer = timer + bobbingSpeed;
                if (timer > Mathf.PI * 2)
                {
                    timer = timer - (Mathf.PI * 2);
                }
            }
            if (waveslice != 0)
            {
                float translateChange = waveslice * bobbingAmount;
                float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, -1.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                headpos.y = midpointY + translateChange;
                headpos.x = midpointX + translateChange;
            }
            else
            {
                Mathf.Lerp(headpos.y, midpointY, 1f);
                Mathf.Lerp(headpos.x, -midpointX, 1f);
            }
            transform.localPosition = headpos;
        }       
    }
}