using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 forward;

    void Start()
    {
        forward = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Vector3.up * 12 + forward * 2f;
    }
}
