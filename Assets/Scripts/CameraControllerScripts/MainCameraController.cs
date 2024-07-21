using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
    
    float invertXValue;
    float invertYValue;
    float rotateX;
    float rotateY;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        invertXValue = (invertX) ? -1 : 1;
        invertYValue = (invertY) ? -1 : 1;

        rotateX += Input.GetAxis("Mouse Y") * invertYValue * rotationSpeed;
        rotateX = Mathf.Clamp(rotateX, minimumVerticalAngle, maximumVerticalAngle);
        rotateY += Input.GetAxis("Mouse X") * invertXValue * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotateX, rotateY, 0);

        var focusPosition = target.position + new Vector3 (framingBalance.x, framingBalance.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, gap);
        transform.rotation = targetRotation;
    }
}
