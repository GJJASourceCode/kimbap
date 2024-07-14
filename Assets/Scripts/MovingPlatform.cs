using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum PlatformDirection
{
    x,
    y,
    z
}

public class MovingPlatform : MonoBehaviour
{
    public PlatformDirection direction;
    public float movementSpeed;
    public float timeToMove;

    private float movingTime = 0;
    private bool isReversed = false;
    private Vector3 directionVector;

    public void CheckDirection()
    {
        switch (direction)
        {
            case PlatformDirection.x:
                break;
            case PlatformDirection.y:
                break;
            case PlatformDirection.z:
                break;
        }
    }

    void Start()
    {
        if (direction == PlatformDirection.x)
        {
            directionVector = Vector3.right;
        }
        else if (direction == PlatformDirection.y)
        {
            directionVector = Vector3.up;
        }
        else if (direction == PlatformDirection.z)
        {
            directionVector = Vector3.forward;
        }
    }

    void Update()
    {
        movingTime += Time.deltaTime;
        if (movingTime < timeToMove)
        {
            isReversed = false;
            transform.position += directionVector * Time.deltaTime * movementSpeed;
        }
        else
        {
            movingTime = 0;
            isReversed = true;
        }

        if (isReversed == true)
        {
            directionVector *= -1;
        }
    }
}