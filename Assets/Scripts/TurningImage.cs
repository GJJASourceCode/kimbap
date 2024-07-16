using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningImage : MonoBehaviour
{
    public int rotSpeed;
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
