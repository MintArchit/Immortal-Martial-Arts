using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 3f;

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var movementInput = (new Vector3(horizontal, 0, vertical)).normalized;

        transform.position += movementInput * movementSpeed * Time.deltaTime;
    }
}
