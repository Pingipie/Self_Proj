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
            collision = true;
            Destroy(this.GetComponent<FloaterIcon>());
            Debug.Log("collisiondetected");
        }
    }
}
