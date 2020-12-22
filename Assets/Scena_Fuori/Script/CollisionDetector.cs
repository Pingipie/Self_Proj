using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{

    GameObject empty;
    bool handDetector;
    GameObject emptyMirror;
    
    private void Start()
    {
        handDetector = false;
        empty = GameObject.Find("TunnelOut");
        emptyMirror = GameObject.Find("Mirror");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hand") && handDetector==false)
        {
            handDetector = true;
            Debug.Log("collision detected");
            empty.GetComponent<TunnelOut>().transition = 1;
            SceneManager.LoadSceneAsync("Scena_Tunnel", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Scena_Fuori");
        }
    }

  

}
