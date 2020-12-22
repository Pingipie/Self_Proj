using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTelephone : MonoBehaviour
{
    GameObject mirror;

    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        mirror = GameObject.Find("Mirror");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow, 1000);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 1000);
        }
    }
}
