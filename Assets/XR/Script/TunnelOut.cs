using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelOut : MonoBehaviour
{
    GameObject Algorithm;
    public GameObject emptyColor;
    GameObject mirrorEmpty;
    GameObject merchEmpty;
    GameObject colliderEmpty;

    Algorithm algorithm;

    int counter;

    int totInteraction;
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

        mirrorEmpty = GameObject.Find("Mirror");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Algorithm") != null)
        {
            mirrorEmpty.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            mirrorEmpty.transform.GetChild(2).gameObject.SetActive(false);
        }

        if (GameObject.Find("Algorithm") != null && Algorithm == null)
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

        if(GameObject.Find("Fade") != null)
        {
            mirrorEmpty.transform.GetChild(0).gameObject.SetActive(true);
            mirrorEmpty.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            mirrorEmpty.transform.GetChild(0).gameObject.SetActive(false);
            mirrorEmpty.transform.GetChild(1).gameObject.SetActive(false);
        }

        if(GameObject.Find("Fade") != null && totInteraction == 5 && merchEmpty != null && colliderEmpty != null)
        {
            merchEmpty = GameObject.Find("Merchandising");

            int nM;
            nM = merchEmpty.transform.childCount;

            for(int i = 0; i < nM; i++)
            {
                merchEmpty.transform.GetChild(i).gameObject.SetActive(true);
            }

            colliderEmpty = GameObject.Find("ColliderRaggi");

            int nC;
            nC = colliderEmpty.transform.childCount;
            
            for(int j = 0; j < nC; j++)
            {
                colliderEmpty.transform.GetChild(j).gameObject.SetActive(true);
            }
        }

    }

    IEnumerator Tunnel()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadSceneAsync("Scena_Tunnel", LoadSceneMode.Additive);

        algorithm = Algorithm.GetComponent<Algorithm>();

        totInteraction = algorithm.totInteraction;
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
