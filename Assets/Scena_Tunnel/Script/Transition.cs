using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
    public int transition;

    void Update()
    {
        if (transition == 1)
        {
            transition = 0;
            StartCoroutine(FirstTransitionScene());
        }
        else if (transition == 2)
        {
            transition = 0;
            StartCoroutine(SecondTransitionScene());
        }
    }

    IEnumerator FirstTransitionScene()
    {
        yield return new WaitForSeconds(16);
        SceneManager.LoadSceneAsync("Scena_Dentro", LoadSceneMode.Additive);
        yield return new WaitForSeconds(1);
        SceneManager.UnloadSceneAsync("Scena_Tunnel");
    }

    IEnumerator SecondTransitionScene()
    {
        yield return new WaitForSeconds(16);
        SceneManager.LoadSceneAsync("Scena_Fuori", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scena_Tunnel");
    }

}
