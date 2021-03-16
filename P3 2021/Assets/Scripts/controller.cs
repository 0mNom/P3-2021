using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller : MonoBehaviour
{

    private InputManager input;

    private void Awake()
    {
        input = new InputManager();
    }

    private void Update()
    {
        float ad = input.Player.AD.ReadValue<float>();
        Debug.Log(ad);

        if (input.Player.Shoot.waspressedthisframe) Debug.Log("SPACE");

    }

    public void move()
    {
    
    }


    private void onEnable()
    {
        input.Enable();
    }


    private void onDisable()
    {
        input.Disable();
    }  

}
