using UnityEngine;

public class portal : MonoBehaviour
{
    public GameObject targetObject; 
    public string collisionTag = "gal2";

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(collisionTag))
        {
            
            transform.position = targetObject.transform.position;
        }
    }
}
