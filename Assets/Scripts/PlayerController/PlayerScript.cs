using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 3f;
    public MainCameraController MainCameraController;

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Check for movement
        float movementAmount = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

        var movementInput = (new Vector3(horizontal, 0, vertical)).normalized;

        var movementDirection = MainCameraController.FlatRotation * movementInput;

        if (movementAmount > 0)
        {
            transform.position += movementDirection * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }
    }
}
