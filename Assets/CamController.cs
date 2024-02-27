using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamController : MonoBehaviour
{
    [SerializeField]
    private Vector2 FlatDir = Vector2.zero;

    private int Fly = 0;
    public int speed = 5;
    public int sens = 5;
    public Vector3 home = Vector3.zero;
    public bool isRMB = false;
    public Vector2 angles = Vector2.zero;
    
    public void WASD(InputAction.CallbackContext movement)
    {
        FlatDir = movement.ReadValue<Vector2>();
    }

    public void Space(InputAction.CallbackContext up)
    {
        Fly = up.ReadValueAsButton() ? 1 : 0;
    }

    public void LCTRL(InputAction.CallbackContext down)
    {
        Fly = down.ReadValueAsButton() ? -1 : 0;
    }

    public void RMB(InputAction.CallbackContext mouse)
    {
        isRMB = mouse.ReadValueAsButton();
    }

    public void Rotate(InputAction.CallbackContext delta)
    {
        if (isRMB)
        {
            angles = delta.ReadValue<Vector2>() * sens * Time.deltaTime;
        }
        else
        {
            angles = Vector2.zero;
        }
    }

    public void ReCentre(InputAction.CallbackContext f)
    {
        if (f.ReadValueAsButton())
        {
            transform.position = home;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 motion = new Vector3(FlatDir.x, Fly, FlatDir.y) * (speed * Time.deltaTime);
        transform.Translate(motion);
        transform.Rotate(Vector3.up,angles.x);
        transform.Rotate(Vector3.right,-(angles.y));
    }
}
