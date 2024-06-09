using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float torque;

    private Rigidbody rb;
    private CapsuleCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        rb.AddTorque(
            new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f).normalized * torque * Time.deltaTime
        );
    }

    bool IsGrounded()
    {
        // Define a layer mask for the ground
        int groundLayer = LayerMask.NameToLayer("Watermelon");
        // Define a raycast distance slightly higher than the player's height
        float raycastDistance = 1f + 0.02f; // Add a small offset to avoid floating-point precision issues

        // Perform a raycast downwards from the player's position
        RaycastHit hit;
        if (
            Physics.Raycast(
                transform.position,
                Vector3.down,
                out hit,
                raycastDistance,
                ~(1 << groundLayer)
            )
        )
        {
            // If the raycast hits the ground, return true
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return true;
        }
        // If the raycast does not hit the ground, return false
        return false;
    }
}
