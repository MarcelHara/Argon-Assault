using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //refs and vars
    [SerializeField] InputAction movement;

    //Initializing
    private void OnEnable() // onEnable happens after awake  YOU HAVE TO DO THIS FOR NEW INPUT SYSTEM
    {
        movement.Enable();
    }

    private void OnDisable() // HAVE TO SPECIFY TO DISABLE IT AFTER ITS FINISHED
    {
        movement.Disable();
    }

    //runtime
    private void Update()
    {
        ThrustMovement();
    }

    //Movement
    private void ThrustMovement()
    {
        float horizontalThrust = movement.ReadValue<Vector2>().x;
        float verticalThrust = movement.ReadValue<Vector2>().y;
        Debug.Log(horizontalThrust);
        Debug.Log(verticalThrust);
    }

}
