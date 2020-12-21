using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    GameObject Algorithm;
    GameObject avatar;

    int counter;
    int blueInteraction;
    int redInteraction;
    int yellowInteraction;
    int greenInteraction;

    bool color;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        blueInteraction = 0;
        redInteraction = 0;
        yellowInteraction = 0;
        greenInteraction = 0;

        color = false;

        avatar = GameObject.Find("AVATARnfb");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Algorithm") != null && Algorithm == null)
            Algorithm = GameObject.Find("Algorithm");
               
        if(color == false && Algorithm != null)
            ChangeColor();

        /*if (Algorithm.GetComponent<Algorithm>().totInteraction == 5)
        {
            blueInteraction = Algorithm.GetComponent<Algorithm>().blueInteraction;
            redInteraction = Algorithm.GetComponent<Algorithm>().redInteraction;
            yellowInteraction = Algorithm.GetComponent<Algorithm>().yellowInteraction;
            greenInteraction = Algorithm.GetComponent<Algorithm>().greenInteraction;
        }*/
    }

    void ChangeColor()
    {
        color = true;

        counter = Algorithm.GetComponent<Algorithm>().totInteraction;

        if (counter == 1)
            avatar.transform.GetChild(1).gameObject.SetActive(true);

        else if (counter == 2)
            avatar.transform.GetChild(2).gameObject.SetActive(true);

        else if (counter == 3)
            avatar.transform.GetChild(3).gameObject.SetActive(true);

        else if (counter == 4)
        {
            avatar.transform.GetChild(4).gameObject.SetActive(true);
            avatar.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if (counter == 5)
            avatar.transform.GetChild(6).gameObject.SetActive(true);

        color = false;
    }
}
