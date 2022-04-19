using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    //runtime
    private void Update()
    {
        //ThrustMovement();
    }

    //Movement
    //private void ThrustMovement()
    //{
    //    //float horizontalThrust = Input.GetAxis("Horizontal");
    //    //float verticalThrust = Input.GetAxis("Vertical");
    //    //Debug.Log(horizontalThrust);
    //    //Debug.Log(verticalThrust);
    //}
}
