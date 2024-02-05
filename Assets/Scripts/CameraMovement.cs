using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Target that the camera will follow
    public float smoothing; // Smoothing variable to make things move nicer
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called every frame, after the Fixed/Update steps
    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
        
    }
}
