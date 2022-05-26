using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //refs and vars
    [Header("General Settings for PlayerController")] // header for the editor to say general settings when looking at this script
    [Tooltip("How fast the ship is moving up and down")]
    [SerializeField] float playerSpeed = 25f;
    [Tooltip("How much the ship is pitching")]
    [SerializeField] float pitchFactor = 1f;
    [Tooltip("How much the ship is Yawing")]
    [SerializeField] float yawFactor = 0f;
    [Tooltip("How much the ship is rolling")]
    [SerializeField] float rollFactor = -50f;
    [Header("Maincontroller for ship pitch")]
    [SerializeField] float controlPitchFactor = -30f;
    [Header("The laser particle system Controller")]
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
            LaserController(true);
        }
        else
        {
            LaserController(false);
        }
    }

    /// <summary>
    /// We add a param to the method so we dont have to duplicate the method twice just to change the emitionModule from true or false.
    /// Instead we pass a paramater called isEnabled and where you would enable with true you rename that with the paramater we have chosen.
    /// </summary>
    /// <param name="isEnabled"></param>
    private void LaserController(bool isEnabled)
    {
        // for every gameobject (anyName) in our var lasers we made, then do something
        foreach(GameObject allLasers in lasers)
        {
            var emitionModule = allLasers.GetComponentInChildren<ParticleSystem>().emission;
            emitionModule.enabled = isEnabled;
        }
    }
}
