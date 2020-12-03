using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float cameraSpeed = 5f;
    private Vector3 targetPosition;

    void Update() 
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * cameraSpeed);
    }
}
