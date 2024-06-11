using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private float rotationSpeed = 500f;

    // private PlayerController playerController;

    void Start()
    {
        // playerController = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CamOrbit();
        }
        else
        {
            CamReset();
        }
        transform.position = target.position;
    }

    private void CamOrbit()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right, -verticalInput);
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }

    private void CamReset()
    {
        Debug.Log(Vector3.Cross(Vector3.up, target.right));
        transform.rotation = Quaternion.LookRotation(
            Vector3.Cross(target.right, Vector3.up),
            Vector3.up
        );
    }
}
