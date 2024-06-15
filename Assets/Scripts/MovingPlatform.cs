using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum platformDirection
{
    x,
    y,
    z
}

public class MovingPlatform : MonoBehaviour
{
    public platformDirection direction;
    public float movementSpeed;
    public float timeToMove;

    private float movingTime = 0;
    private bool isReversed = false;
    private Vector3 directionVector;

    public void CheckDirection()
    {
        switch (direction)
        {
            case platformDirection.x:
                break;
            case platformDirection.y:
                break;
            case platformDirection.z:
                break;
        }
    }

    void Start()
    {
        if (direction == platformDirection.x)
        {
            directionVector = Vector3.right;
        }
        else if (direction == platformDirection.y)
        {
            directionVector = Vector3.up;
        }
        else if (direction == platformDirection.z)
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
