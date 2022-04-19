using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //refs and vars
    Vector2 moveDirection = Vector2.zero;
    [SerializeField]float playerSpeed = 5f;

    //runtime
    private void Update()
    {
        ThrustMovement();
    }

    //Movement
    private void ThrustMovement()
    {
        float xThrust = Input.GetAxis("Horizontal");
        float yThrust = Input.GetAxis("Vertical");
        Debug.Log(xThrust);
        Debug.Log(yThrust);
    }
}
