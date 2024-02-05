using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange; // How much we'll change the camera offset
    public Vector3 playerChange; // How much to move the player after room change
    private CameraMovement playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Change what the camera offset is
            playerCam.minPosition += cameraChange;
            playerCam.maxPosition += cameraChange;
            collision.transform.position += playerChange;
        }
    }
}
