using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;

    Vector3 offset;

    public float magsqr;
    private bool rot;
    
    // Start is called before the first frame update
    void Start()
    {
        rot = false;
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
           rb.AddForce(new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), Random.Range(-.5f, .5f)));
        if (rot == false)
        {
            rot = true;
            StartCoroutine(rotation());
        }
    }
    
    IEnumerator rotation()
    {
        float n = 0;

        float i;
        i = Random.Range(-20f, 20f);
        float j;
        j = Random.Range(-20f, 20f);
        float k;
        k = Random.Range(-20f, 20f);
        float a = 0, b = 0, c = 0;
        while (n == 0)
        {
            rb.transform.Rotate(new Vector3(a, b, c));
            if (i > 0)
                a = .3f;
            else if (i < 0)
                a = -.3f;
            if (j > 0)
                b = .3f;
            else if (j < 0)
                b = -.3f;
            if (k > 0)
                c = .3f;
            else if (k < 0)
                c = -.3f;
            yield return new WaitForSeconds(.01f);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(collision.contacts[0].normal * 1f);
    }*/
}
