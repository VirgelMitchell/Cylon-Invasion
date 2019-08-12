﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

using CPIM = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager;

public class MovementControl : MonoBehaviour
{
    [Tooltip("in m")] [SerializeField] float horizontalRange = 10f;
    [Tooltip("in m")] [SerializeField] float verticalRange = 5.5f;
    [Tooltip("in m/s^2")] [SerializeField] float speed = 25f;
    [SerializeField] float pitchFactor = -0.8f;
    [SerializeField] float yawFactor = 1.4f;
    [SerializeField] float rollFactor = 5f;

    Vector2 sThrow = new Vector2();
    Vector3 displacement = new Vector3();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        TranslateShip();
        RotateShip();
    }

    private void GetInput()
    {
        sThrow.x = CPIM.GetAxis("Horizontal");
        displacement.x = sThrow.x * speed * Time.deltaTime;

        sThrow.y = CPIM.GetAxis("Vertical");
        displacement.y = sThrow.y * speed * Time.deltaTime;

        print($"Throw = {sThrow} ===> {displacement}m/f");
    }

    void TranslateShip()
    {
        Vector3 currentPosition = transform.localPosition;
        Vector3 newPosition = currentPosition + displacement;
        float newX, newY;
        newX = Mathf.Clamp(newPosition.x, -horizontalRange, horizontalRange);
        newY = Mathf.Clamp(newPosition.y, -verticalRange, verticalRange);
        Vector3 clampedNewPos = new Vector3(newX, newY, newPosition.z);

        transform.localPosition = clampedNewPos;
    }

    void RotateShip()
    {
        float pitch = (transform.localPosition.y + sThrow.y) * pitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = sThrow.x * rollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}