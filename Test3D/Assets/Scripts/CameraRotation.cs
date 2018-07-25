using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    public float speed = 5.0f;    
    
    void LateUpdate()
    {
        offset = transform.position - player.position;
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftAlt))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * speed, Vector3.right) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player);            
        }
    }
}
