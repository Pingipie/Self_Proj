using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hand"))
        {
            Debug.Log("collision detected");
            SceneManager.LoadSceneAsync("Scena_Tunnel", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Scena_Fuori");

        }
    }
}
