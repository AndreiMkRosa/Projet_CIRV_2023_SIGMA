using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        //distance (in angles) to rotate on each frame. distance = speed*time
    float angle = rotationSpeed * Time.deltaTime;
        //rotate on Y
        transform.Rotate(Vector3.up * angle, Space.World);
    }

}
