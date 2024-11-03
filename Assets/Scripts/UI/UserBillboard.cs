using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBillboard : MonoBehaviour
{
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            //Debug.Log(FindFirstObjectByType<Camera>().name);
        }

        if (mainCamera == null)
            return;

        transform.LookAt(mainCamera.transform);
        transform.Rotate(Vector3.up * 180);
    }
}
