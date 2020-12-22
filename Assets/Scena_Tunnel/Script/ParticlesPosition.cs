using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPosition : MonoBehaviour
{
    GameObject Camera;
    Vector3 offset;

    private void Start()
    {
        Camera = GameObject.Find("VR Camera");
        offset = new Vector3(-13.0f, -1.6f, -167.6f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.transform.position + offset;
    }
}
