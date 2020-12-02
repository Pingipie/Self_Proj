using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Algorithm : MonoBehaviour
{
    private GameObject[] Blue;
    private GameObject[] Red;
    private GameObject[] Yellow;
    private GameObject[] Green;

    private int totInteraction;
    private int blueInteraction;
    private int redInteraction;
    private int yellowInteraction;
    private int greenInteraction;

    // Start is called before the first frame update
    void Start()
    {
        Blue = GameObject.FindGameObjectsWithTag("Blue");
        Red = GameObject.FindGameObjectsWithTag("Red");
        Yellow = GameObject.FindGameObjectsWithTag("Yellow");
        Green = GameObject.FindGameObjectsWithTag("Green");

        Blue = sortArray(Blue);
        Red = sortArray(Red);
        Yellow = sortArray(Yellow);
        Green = sortArray(Green);

        Debug.Log(Blue[0].name);

        totInteraction = 0;
        blueInteraction = 0;
        redInteraction = 0;
        yellowInteraction = 0;
        greenInteraction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //prima interazione
        if (totInteraction == 0)
        {
            Debug.Log(Blue[totInteraction].GetComponent<CheckInteraction>().collision);
            if (Blue[totInteraction].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(disappear(Blue[totInteraction]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Blue[1]));
                StartCoroutine(appear(Blue[2]));

                totInteraction ++;
                blueInteraction ++;

                StartCoroutine(disappear(Green[totInteraction]));
            }

            if (Red[totInteraction].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(disappear(Red[totInteraction]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Red[1]));
                StartCoroutine(appear(Red[2]));

                totInteraction++;
                redInteraction++;

                StartCoroutine(disappear(Green[totInteraction]));
            }

            if (Yellow[totInteraction].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(disappear(Yellow[totInteraction]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Yellow[1]));
                StartCoroutine(appear(Yellow[2]));

                totInteraction++;
                yellowInteraction++;

                StartCoroutine(disappear(Green[totInteraction]));
            }

            if (Green[totInteraction].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(disappear(Green[totInteraction]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Green[1]));
                StartCoroutine(appear(Green[2]));

                totInteraction++;
                greenInteraction++;

                StartCoroutine(disappear(Yellow[totInteraction])); //sparisce ovunque il verde tranne qui il giallo
            }
        } //fine prima interazione
        
    }

    //Coroutine per far sparire l'icona
    IEnumerator disappear(GameObject icon)
    {
        yield return new WaitForSeconds(1); //per feedback su controller

        //va inserita l'animazione della sparizione, si potrebbe usare un bool associato all'animazione poi per far partire
        //la sparizione di Collider e Render
        //comunque vanno tolti Render e Collider per diminuire il peso grafico

        icon.GetComponent<MeshRenderer>().enabled = false;
        icon.GetComponent<MeshCollider>().enabled = false;
    }

    IEnumerator appear(GameObject icon)
    {
        yield return new WaitForSeconds(1);

        //va inserita l'animazione dell'apparizione, si potrebbe usare un bool associato all'animazione poi per far partire
        //l'apparizione di Collider e Render

        icon.GetComponent<MeshRenderer>().enabled = true;
        icon.GetComponent<MeshCollider>().enabled = true;
    }

    private GameObject[] sortArray(GameObject[] icons)
    {
        GameObject[] sorted = new GameObject[16];

        foreach(GameObject icon in icons)
        {
            string name = icon.name;
            int number = System.Int32.Parse(Regex.Match(name, @"\d+").Value);

            sorted[number - 1] = icon;
        }

        return sorted;
    }
}
