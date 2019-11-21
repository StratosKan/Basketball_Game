using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    //This script is for android phone implementation with touch screen.

    private float InitialTouchTime;
    private float FinalTouchTime;
    private Vector2 InitialTouchPosition;
    private Vector2 FinalTouchPosition;

    private float XaxisForce;
    private float YaxisForce;
    private float ZaxisForce;

    private Vector3 RequireForce;

    public Rigidbody ball;

    void Start()
    {
        ball.useGravity = false;
    }

    public void OnTouchDown()
    {
        InitialTouchTime = Time.time;
        InitialTouchPosition = Input.mousePosition;
    }

    public void OnTouchUp()
    {
        FinalTouchTime = Time.time;
        FinalTouchPosition = Input.mousePosition;

        BallThrow();
    }

    private void BallThrow()
    {
        XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x;
        YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y;
        ZaxisForce = FinalTouchTime - InitialTouchTime;

        RequireForce = new Vector3(-XaxisForce, YaxisForce, -ZaxisForce);

        ball.useGravity = true;
        ball.velocity = RequireForce;
    }
}
