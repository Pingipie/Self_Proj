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
    GameObject blackSphereFade;
    GameObject Light;

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
        blackSphereFade = GameObject.Find("FadeSphereBlack");
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
                Light = GameObject.Find("Luce");
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

        while (blackSphereFade.GetComponent<MeshRenderer>().material.color.a < 1)
        {
            Color color = blackSphereFade.GetComponent<MeshRenderer>().material.color;
            color.a += .01f;
            Light.GetComponent<Light>().intensity -= .01f;
            blackSphereFade.GetComponent<MeshRenderer>().material.color = color;
            yield return new WaitForSeconds(.01f);
        }

        yield return new WaitForSeconds(4f);

        SceneManager.UnloadSceneAsync("Scena_Dentro");

        SceneManager.LoadSceneAsync("Scena_Tunnel", LoadSceneMode.Additive);

        algorithm = Algorithm.GetComponent<Algorithm>();

        totInteraction = algorithm.totInteraction;
        blueInteraction = algorithm.blueInteraction;
        redInteraction = algorithm.redInteraction;
        yellowInteraction = algorithm.yellowInteraction;
        greenInteraction = algorithm.greenInteraction;

        while (blackSphereFade.GetComponent<MeshRenderer>().material.color.a > 0)
        {
            Color color = blackSphereFade.GetComponent<MeshRenderer>().material.color;
            color.a -= .01f;
            blackSphereFade.GetComponent<MeshRenderer>().material.color = color;
            yield return new WaitForSeconds(.01f);
        }

        emptyColor.GetComponent<EmptyColor>().blueInteraction = blueInteraction;
        emptyColor.GetComponent<EmptyColor>().redInteraction = redInteraction;
        emptyColor.GetComponent<EmptyColor>().yellowInteraction = yellowInteraction;
        emptyColor.GetComponent<EmptyColor>().greenInteraction = greenInteraction;
    }
}
