using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [Header("Camera Controller")]
    public Transform target;
    public float gap = 3f;
    public float rotationSpeed = 6f;

    [Header("Camera Handling")]
    public float minimumVerticalAngle = -14f;
    public float maximumVerticalAngle = 90f;
    public Vector2 framingBalance;
    public bool invertX;
    public bool invertY;

    float rotateX;
    float rotateY;
    float invertXValue;
    float invertYValue;

    [Header("Mobile Input")]
    public bool mobileInput;
    public FloatingJoystick FloatingJoystick;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        invertXValue = (invertX) ? -1 : 1;
        invertYValue = (invertY) ? -1 : 1;

        if (mobileInput)
        {
            rotateX += FloatingJoystick.Vertical * invertYValue * rotationSpeed;
            rotateY += FloatingJoystick.Horizontal * invertXValue * rotationSpeed;
        }
        else
        {
            rotateX += Input.GetAxis("Mouse Y") * invertYValue * rotationSpeed;
            rotateY += Input.GetAxis("Mouse X") * invertXValue * rotationSpeed;
        }

        rotateX = Mathf.Clamp(rotateX, minimumVerticalAngle, maximumVerticalAngle);

        var targetRotation = Quaternion.Euler(rotateX, rotateY, 0);

        var focusPosition = target.position + new Vector3 (framingBalance.x, framingBalance.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, gap);
        transform.rotation = targetRotation;
    }

    public Quaternion FlatRotation => Quaternion.Euler(0, rotateY, 0);
}
