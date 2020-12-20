using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;

    Vector3 offset;

    public float magsqr;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Camera Offset");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = player.transform.position - transform.position;
        magsqr = offset.sqrMagnitude;

        if (magsqr > 1f)
            rb.AddForce(.01f * offset.normalized / magsqr);
        else
            rb.AddForce(new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)));
    }
}
