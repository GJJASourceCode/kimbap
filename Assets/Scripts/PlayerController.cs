using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float torque;
    public float rotationSpeed;
    public List<GameObject> textParticles;

    private Rigidbody rb;
    private CapsuleCollider collider;

    private Transform savePoint;


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
        rb.AddTorque(transform.right * Input.GetAxisRaw("Vertical") * torque * Time.deltaTime);
        rb.AddTorque(Vector3.up * Input.GetAxisRaw("Horizontal") * torque * Time.deltaTime);
        // if (Input.GetAxisRaw("Horizontal") != 0)
        // {
        //     float rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        //     transform.Rotate(Vector3.up, rotation);
        // }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = savePoint.position + Vector3.up * 5f;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            StartCoroutine(ShoeTextParticle());
        }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Save"))
        {
            savePoint = other.transform;
        }
    }

    IEnumerator ShoeTextParticle()
    {
        int index = Random.Range(0, textParticles.Count);
        GameObject text = Instantiate(textParticles[index], transform.position + Vector3.up * 12, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Destroy(text);
    }
    
}
