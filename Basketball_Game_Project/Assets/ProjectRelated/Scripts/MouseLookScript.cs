using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    //Add this as a component to your main camera
    //Simple rotation no smoothing, no accelaration

    [Header("Sensitivity for camera")]
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    [Header("Clamp values for camera")]
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    float rotationX = 0f;

    bool pressedEsc = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//lock cursor in game window 
    }

    void Update()
    { 
        ToRotateCamera();
    }


    public void ToRotateCamera() 
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            pressedEsc = !pressedEsc;
            if (pressedEsc)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        } //Debug Escape key since actual escape key is funky

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            rotationX = Input.GetAxis("Mouse X") * sensitivityX;
            transform.parent.Rotate(0, rotationX, 0);

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);
        }
    }
}