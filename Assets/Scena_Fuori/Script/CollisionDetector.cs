using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{

    GameObject empty;

    private void Start()
    {
        empty = GameObject.Find("TunnelOut");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hand"))
        {
            Debug.Log("collision detected");
            empty.GetComponent<TunnelOut>().transition = 1;
            SceneManager.LoadSceneAsync("Scena_Tunnel", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Scena_Fuori");

        }
    }
}
