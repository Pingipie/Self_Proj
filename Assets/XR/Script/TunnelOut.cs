using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelOut : MonoBehaviour
{
    GameObject Algorithm;
    public GameObject emptyColor;

    Algorithm algorithm;

    int counter;
    int blueInteraction;
    int redInteraction;
    int yellowInteraction;
    int greenInteraction;

    public int transition;

    // Start is called before the first frame update
    void Start()
    {
        transition = 0;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Algorithm") != null && Algorithm == null)
            Algorithm = GameObject.Find("Algorithm");


        if (GameObject.Find("Algorithm") != null)
        {
            if (Algorithm.GetComponent<Algorithm>().totInteraction == 5 && counter == 0)
            {
                counter = 1;
                transition = 2;
                StartCoroutine(Tunnel());
            }
        }

        if(GameObject.Find("ChangeColor") != null && emptyColor == null)
        {
            emptyColor = GameObject.Find("ChangeColor");
            emptyColor.GetComponent<Transition>().transition = transition;
        }
    }

    IEnumerator Tunnel()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadSceneAsync("Scena_Tunnel", LoadSceneMode.Additive);

        algorithm = Algorithm.GetComponent<Algorithm>();
        blueInteraction = algorithm.blueInteraction;
        redInteraction = algorithm.redInteraction;
        yellowInteraction = algorithm.yellowInteraction;
        greenInteraction = algorithm.greenInteraction;

        SceneManager.UnloadSceneAsync("Scena_Dentro");

        yield return new WaitForSeconds(.3f);

        emptyColor.GetComponent<EmptyColor>().blueInteraction = blueInteraction;
        emptyColor.GetComponent<EmptyColor>().redInteraction = redInteraction;
        emptyColor.GetComponent<EmptyColor>().yellowInteraction = yellowInteraction;
        emptyColor.GetComponent<EmptyColor>().greenInteraction = greenInteraction;
    }
}
