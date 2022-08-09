using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public Transform target;
    public float smoothing;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPositon = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPositon.x = Mathf.Clamp(targetPositon.x, minPosition.x, maxPosition.x);
            targetPositon.y = Mathf.Clamp(targetPositon.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPositon, smoothing);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
