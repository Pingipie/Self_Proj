using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSphere : MonoBehaviour
{

    private GameObject emptyColor;
    private GameObject algo;
    private GameObject fa;

    private bool go;

    private void Start()
    {
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ChangeColor") != null && emptyColor == null)
        {
            emptyColor = GameObject.Find("ChangeColor");
        }

        if(emptyColor != null && go == false)
        {
            go = true;
            StartCoroutine(fade());
        }

        if (GameObject.Find("Algorithm") != null && algo == null)
        {
            algo = GameObject.Find("Algorithm");
            StartCoroutine(inverseFade());
        }
        else if(GameObject.Find("Fade") != null && fa == null && GameObject.Find("Merchandising").transform.GetChild(0).gameObject.activeSelf == true)
        {
            fa = GameObject.Find("Fade");
            StartCoroutine(inverseFade());
        }
    }

    IEnumerator fade()
    {
        yield return new WaitForSeconds(5);
        float i = 1.7f;
        while (i > .5f)
        {
            this.gameObject.GetComponent<Renderer>().material.SetFloat("_vectPos", i);
            i -= 0.002f;
            yield return new WaitForSeconds(.0005f);
        }
        while (i > -1.24f)
        {
            this.gameObject.GetComponent<Renderer>().material.SetFloat("_vectPos", i);
            i -= 0.008f;
            yield return new WaitForSeconds(.0005f);
        }
    }

    IEnumerator inverseFade()
    {
        float i = 0f;
        while (i < 1.0001f)
        {
            this.gameObject.GetComponent<Renderer>().material.SetFloat("_alpha", i);
            i += 0.05f;
            yield return new WaitForSeconds(.03f);
        }

        this.gameObject.GetComponent<Renderer>().material.SetFloat("_vectPos", 1.7f);
    }
}
