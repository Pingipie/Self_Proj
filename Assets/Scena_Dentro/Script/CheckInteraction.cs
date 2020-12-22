using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    public bool collision;

    private void Awake()
    {
        collision = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hand")) {
            this.GetComponent<AudioSource>().Play();
            collision = true;
            Destroy(this.GetComponent<FloaterIcon>());
            Debug.Log("collisiondetected");
        }
    }
}
