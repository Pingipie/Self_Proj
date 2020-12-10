using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TransitionScene());

    }

    IEnumerator TransitionScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync("Scena_Dentro", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scena_Tunnel");

    }



}
