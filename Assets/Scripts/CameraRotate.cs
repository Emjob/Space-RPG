using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject Camera;
    public Vector2 turn;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (turn.y > 60)
        {
            turn.y = 60;
        }
        else if (turn.y < -35)
        {
            turn.y = -35;
        }

        if (turn.x > 80)
        {
            turn.x = 80;
        }
        else if (turn.x < -80)
        {
            turn.x = -80;
        }

        Camera.transform.localRotation = Quaternion.Euler(turn.y, -turn.x, 0);
    }
}
