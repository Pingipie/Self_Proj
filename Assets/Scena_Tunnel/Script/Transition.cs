using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
    public int transition;
    private bool t1;
    private bool t2;

    private void Start()
    {
        t1 = false;
        t2 = false;

    }




    void Update()
    {
        if (transition == 1 && t1==false)
        {
            t1 = true;
        
            StartCoroutine(FirstTransitionScene());
        }
        else if (transition==2 && t2==false)
        {
            t2 = true;
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
