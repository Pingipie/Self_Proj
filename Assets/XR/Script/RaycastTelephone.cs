using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTelephone : MonoBehaviour
{
    GameObject mirror;

    public RaycastHit hit;
    public bool ray;

    // Start is called before the first frame update
    void Start()
    {
        mirror = GameObject.Find("Mirror");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
        print(ray);
    }
}
