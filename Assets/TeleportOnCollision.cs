using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public GameObject targetObject; 
    public string collisionTag = "Black"; 

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag(collisionTag))
        {
               transform.position = targetObject.transform.position;
        }
    }
}
