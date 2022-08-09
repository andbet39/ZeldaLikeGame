using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChange : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;
    public CameraMovement cam;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        triggered= false;
        Debug.Log("started");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Triggered");
 
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
