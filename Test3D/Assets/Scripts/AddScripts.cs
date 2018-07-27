using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
public class AddScripts : MonoBehaviour
{
    public Toggle[] toggle;	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    //for (int i = 0; i < toggle.Length; i++)
                    //{
                    //    toggle[i].gameObject.SetActive(true);
                    //}
                    AddScript(toggle[0], hit.transform.gameObject, "ObjectMovement");
                    AddScript(toggle[1], hit.transform.gameObject, "ObjectRotation");
                    AddScript(toggle[2], hit.transform.gameObject, "ObjectScaling");
                }
            }
        }
    }

    void AddScript(Toggle toggle, GameObject obj, string script)
    {
        if (obj.tag == "GameObject")
        {
            if (toggle.isOn && obj.GetComponent(script)  == null)
            {
                obj.AddComponent(Type.GetType(script));
            }
            else if (!toggle.isOn && obj.GetComponent(script) != null)
            {
                var temp = obj.GetComponent(script);
                Destroy(temp);
            }
        }        
    }    
}
#endif