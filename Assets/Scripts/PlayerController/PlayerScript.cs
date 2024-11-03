using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 9f;
    public float rotationSpeed = 700f;
    public MainCameraController MainCameraController;
    Quaternion requiredRotation;

    [Header("Player Collision & Gravity")]
    public CharacterController CharacterController;

    [Header("Player Animater")]
    public Animator animator;

    [Header("Mobile Input")]
    public bool mobileInput;
    public FixedJoystick FixedJoystick;

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal;
        float vertical;
        if (mobileInput)
        {
            horizontal = FixedJoystick.Horizontal;
            vertical = FixedJoystick.Vertical;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }

        // Check for movement
        float movementAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        var movementInput = (new Vector3(horizontal, 0, vertical)).normalized;

        var movementDirection = MainCameraController.FlatRotation * movementInput;

        if (movementAmount > 0)
        {
            CharacterController.Move(movementDirection * movementSpeed * Time.deltaTime);
            requiredRotation = Quaternion.LookRotation(movementDirection);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation, rotationSpeed * Time.deltaTime);
        animator.SetFloat("movementValue", movementAmount, 0.2f, Time.deltaTime);
    }
}
