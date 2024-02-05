using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange; // How much we'll change the camera offset
    public Vector3 playerChange; // How much to move the player after room change
    private CameraMovement playerCam;
    
    // Title Card variables
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
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

            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo()
    {
        float fadeTime = 1.5f;
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        yield return FadeText(fadeTime, placeText);
        text.SetActive(false);
        placeText.color = new Color(placeText.color.r, placeText.color.g, placeText.color.b, 1);
    }
    private IEnumerator FadeText(float fadeTime, Text t)
    {
        if (t == null)
        {
            Debug.Log("Text object is null");
            yield break;
        }
        while (t.color.a > 0.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
    }
}
