using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaling : MonoBehaviour
{
    private Vector3 temp;
	
	void Update ()
    {
        temp = transform.localScale;

		if (Input.GetKey(KeyCode.UpArrow))
        {
            temp.y += Time.deltaTime;
            transform.localScale = temp;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            temp.y -= Time.deltaTime;
            transform.localScale = temp;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            temp.x += Time.deltaTime;
            transform.localScale = temp;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            temp.x -= Time.deltaTime;
            transform.localScale = temp;
        }
    }
}
