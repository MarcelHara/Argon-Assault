using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //refs and vars
    [SerializeField]float playerSpeed = 25f;

    //runtime
    private void Update()
    {
        ThrustMovement();
    }

    private void Start()
    {
        transform.localPosition = new Vector3(0, -25, 0); // fixes the position of the object when the timeline edits it
    }

    //Movement
    private void ThrustMovement()
    {
        float xThrust = Input.GetAxis("Horizontal");
        float yThrust = Input.GetAxis("Vertical");

        float xOffset = xThrust * Time.deltaTime * playerSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -10f, 5f);

        float yOffset = yThrust * Time.deltaTime * playerSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newYPos, -17f, -8f);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }
}
