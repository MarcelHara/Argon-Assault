using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //refs and vars
    [SerializeField] float playerSpeed = 25f;
    [SerializeField] float pitchFactor = 1f;
    [SerializeField] float yawFactor = 0f;
    [SerializeField] float rollFactor = -50f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] GameObject[] lasers;  // array for the lasers
    float xThrust;
    float yThrust;

    //runtime
    private void Update()
    {
        ThrustMovement();
        PlayerRotation();
        Firing();
    }

    //Rotation
    private void PlayerRotation()
    {
        float pitchPositionSetter = transform.localPosition.y * pitchFactor;
        float pitchPlayerInputReciever = yThrust * controlPitchFactor;
        float pitch = pitchPositionSetter + pitchPlayerInputReciever;

        float yaw = transform.localPosition.x * yawFactor;

        float roll = xThrust * rollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    //Movement
    private void ThrustMovement()
    {
        xThrust = Input.GetAxis("Horizontal");
        yThrust = Input.GetAxis("Vertical");

        float xOffset = xThrust * Time.deltaTime * playerSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -15f, 15f);

        float yOffset = yThrust * Time.deltaTime * playerSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newYPos, -16f, -2f);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    // Firing Mechanic

    /// <summary>
    /// 0 Near get mousebuttondown is left click, 1 is right click and 2 is middle mouse.
    /// </summary>
    private void Firing()
    {
        if (Input.GetButton("Fire1"))
        {
            LasersOn();
        }
        else
        {
            LasersOff();
        }
    }

    // turns on laser array to make laser particles fire
    private void LasersOn()
    {
        // for every gameobject (anyName) in our var lasers we made, then do something
        foreach(GameObject allLasers in lasers)
        {
            allLasers.SetActive(true);
        }
    }

    // turns off laser array to make laser particles not show
    private void LasersOff()
    {
        foreach (GameObject allLasers in lasers)
        {
            allLasers.SetActive(false);
        }
    }
}
