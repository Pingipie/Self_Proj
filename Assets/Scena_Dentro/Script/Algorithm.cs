using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Video;

public class Algorithm : MonoBehaviour
{
    private GameObject[] Blue; //InformationIcon
    private GameObject[] Red; //MovieIcon
    private GameObject[] Yellow; //WebStarIcon
    private GameObject[] Green; //WebStarIcon

    private GameObject[] WebStarMedia;
    private GameObject[] MovieMedia;
    private GameObject[] InformationMedia;

    public int totInteraction;
    public int blueInteraction;
    public int redInteraction;
    public int yellowInteraction;
    public int greenInteraction;

    private string[] chronology;

    private int crr; //per la concorrenza
    private int exit;

    // Start is called before the first frame update
    void Start()
    {
        Blue = GameObject.FindGameObjectsWithTag("Blue");
        Red = GameObject.FindGameObjectsWithTag("Red");
        Yellow = GameObject.FindGameObjectsWithTag("Yellow");
        Green = GameObject.FindGameObjectsWithTag("Green");

        Blue = sortArray(Blue, Blue.Length);
        Red = sortArray(Red, Red.Length);
        Yellow = sortArray(Yellow, Yellow.Length);
        Green = sortArray(Green, Green.Length);

        WebStarMedia = GameObject.FindGameObjectsWithTag("WebStar");
        MovieMedia = GameObject.FindGameObjectsWithTag("Movie");
        InformationMedia = GameObject.FindGameObjectsWithTag("Information");

        WebStarMedia = sortArray(WebStarMedia, WebStarMedia.Length);
        MovieMedia = sortArray(MovieMedia, MovieMedia.Length);
        InformationMedia = sortArray(InformationMedia, InformationMedia.Length);

        //Debug.Log(Blue[0].name);

        totInteraction = 0;
        blueInteraction = 0;
        redInteraction = 0;
        yellowInteraction = 0;
        greenInteraction = 0;

        chronology = new string[6];

        crr = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (crr == 1)
        {
            Implementation();
        }
    }

    private void Implementation()
    {
        crr = 0;
        exit = 0;

        //prima interazione
        if (totInteraction == 0)
        {
            //Debug.Log(Blue[1].name);
            if (Blue[0].GetComponent<CheckInteraction>().collision)
            {
                Blue[1].AddComponent<EvenParticlesAttraction>();
                //Blue[2].AddComponent<OddParticlesAttraction>();

                print(Blue[0].GetComponentInChildren<ParticleSystem>());
                Blue[1].GetComponent<EvenParticlesAttraction>().AffectedParticles = Blue[0].GetComponentInChildren<ParticleSystem>();
                //Blue[2].GetComponent<OddParticlesAttraction>().AffectedParticles = Blue[0].GetComponentInChildren<ParticleSystem>();

                StartCoroutine(AssignMedia(Blue[0], InformationMedia[blueInteraction]));
                StartCoroutine(disappear(Blue[0]));

                StartCoroutine(appear(Blue[1]));
                //StartCoroutine(appear(Blue[2]));
                //va inserita l'apertura del media

                totInteraction++;
                blueInteraction++;

                chronology[0] = "blue";

                //StartCoroutine(disappear(Green[0]));
                greenInteraction = -1;
            }

            else if (Red[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Red[0], MovieMedia[0]));
                StartCoroutine(disappear(Red[0]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Red[1]));
                StartCoroutine(appear(Red[2]));

                totInteraction++;
                redInteraction++;

                chronology[0] = "red";

                StartCoroutine(disappear(Green[0]));
                greenInteraction = -1;
            }

            else if (Yellow[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Yellow[0], WebStarMedia[yellowInteraction]));
                StartCoroutine(disappear(Yellow[0]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Yellow[1]));
                StartCoroutine(appear(Yellow[2]));

                totInteraction++;
                yellowInteraction++;

                chronology[0] = "yellow";

                StartCoroutine(disappear(Green[0]));
                greenInteraction = -1;
            }

            else if (Green[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Green[0], WebStarMedia[greenInteraction]));
                StartCoroutine(disappear(Green[0]));

                //va inserita l'apertura del media

                StartCoroutine(appear(Green[1]));
                StartCoroutine(appear(Green[2]));

                totInteraction++;
                greenInteraction++;

                chronology[0] = "green";

                StartCoroutine(disappear(Yellow[0]));
                yellowInteraction = -1;
            }



        } //fine prima interazione

        //inizio seconda interazione
        else if (totInteraction == 1)
        {
            foreach (GameObject blueIcon in Blue)
            {
                if (blueInteraction == 1 && blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<MeshCollider>().enabled)
                {
                    StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                    StartCoroutine(disappear(blueIcon));

                    StartCoroutine(appear(Blue[3]));
                    StartCoroutine(appear(Blue[4]));

                    totInteraction++;
                    blueInteraction++;

                    chronology[1] = "blue";
                }
            }

            if (blueInteraction == 0 && Blue[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Blue[0], InformationMedia[blueInteraction]));
                StartCoroutine(disappear(Blue[0]));

                StartCoroutine(appear(Blue[1]));
                StartCoroutine(appear(Blue[2]));

                totInteraction++;
                blueInteraction++;

                chronology[1] = "blue";
            }

            else if (redInteraction == 1 && Red[1].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Red[1], MovieMedia[redInteraction]));
                StartCoroutine(disappear(Red[1]));

                StartCoroutine(appear(Red[3]));
                StartCoroutine(appear(Red[4]));

                totInteraction++;
                redInteraction++;

                chronology[1] = "red";
            }

            else if (redInteraction == 1 && Red[2].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Red[2], MovieMedia[redInteraction]));
                StartCoroutine(disappear(Red[2]));

                StartCoroutine(appear(Red[3]));
                StartCoroutine(appear(Red[4]));

                totInteraction++;
                redInteraction++;

                chronology[1] = "red";
            }

            else if (redInteraction == 0 && Red[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Red[0], MovieMedia[redInteraction]));
                StartCoroutine(disappear(Red[0]));

                StartCoroutine(appear(Red[1]));
                StartCoroutine(appear(Red[2]));

                totInteraction++;
                redInteraction++;

                chronology[1] = "red";
            }

            else if (yellowInteraction == 1 && Yellow[1].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Yellow[1], WebStarMedia[yellowInteraction]));
                StartCoroutine(disappear(Yellow[1]));

                StartCoroutine(appear(Yellow[3]));
                StartCoroutine(appear(Yellow[4]));

                totInteraction++;
                yellowInteraction++;

                chronology[1] = "yellow";
            }

            else if (yellowInteraction == 1 && Yellow[2].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Yellow[2], WebStarMedia[yellowInteraction]));
                StartCoroutine(disappear(Yellow[2]));

                StartCoroutine(appear(Yellow[3]));
                StartCoroutine(appear(Yellow[4]));

                totInteraction++;
                yellowInteraction++;

                chronology[1] = "yellow";
            }

            else if (yellowInteraction == 0 && Yellow[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Yellow[0], WebStarMedia[yellowInteraction]));
                StartCoroutine(disappear(Yellow[0]));

                StartCoroutine(appear(Yellow[1]));
                StartCoroutine(appear(Yellow[2]));

                totInteraction++;
                yellowInteraction++;

                chronology[1] = "yellow";
            }

            else if (greenInteraction == 1 && Green[1].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Green[1], WebStarMedia[greenInteraction]));
                StartCoroutine(disappear(Green[1]));

                StartCoroutine(appear(Green[3]));
                StartCoroutine(appear(Green[4]));

                totInteraction++;
                greenInteraction++;

                chronology[1] = "green";
            }

            else if (greenInteraction == 1 && Green[2].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Green[2], WebStarMedia[greenInteraction]));
                StartCoroutine(disappear(Green[2]));

                StartCoroutine(appear(Green[3]));
                StartCoroutine(appear(Green[4]));

                totInteraction++;
                greenInteraction++;

                chronology[1] = "green";
            }

            else if (greenInteraction == 0 && Green[0].GetComponent<CheckInteraction>().collision)
            {
                StartCoroutine(AssignMedia(Green[0], WebStarMedia[greenInteraction]));
                StartCoroutine(disappear(Green[0]));

                StartCoroutine(appear(Green[1]));
                StartCoroutine(appear(Green[2]));

                totInteraction++;
                greenInteraction++;

                chronology[1] = "green";
            }
        } //fine seconda interazione

        //inizio terza interazione
        else if (totInteraction == 2)
        {
            if (blueInteraction == 2)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[5]));
                        StartCoroutine(appear(Blue[6]));

                        StartCoroutine(disappear(Yellow[0]));
                        yellowInteraction = -1;

                        totInteraction++;
                        blueInteraction++;

                        chronology[2] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 1)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[3]));
                        StartCoroutine(appear(Blue[4]));

                        totInteraction++;
                        blueInteraction++;

                        chronology[2] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 0)
            {
                if (Blue[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Blue[0], InformationMedia[blueInteraction]));
                    StartCoroutine(disappear(Blue[0]));

                    StartCoroutine(appear(Blue[1]));
                    StartCoroutine(appear(Blue[2]));

                    totInteraction++;
                    blueInteraction++;

                    chronology[2] = "blue";
                }
            }

            if (redInteraction == 2)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[5]));
                        StartCoroutine(appear(Red[6]));

                        StartCoroutine(disappear(Yellow[0]));
                        yellowInteraction = -1;

                        totInteraction++;
                        redInteraction++;

                        chronology[2] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 1)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[3]));
                        StartCoroutine(appear(Red[4]));

                        totInteraction++;
                        redInteraction++;

                        chronology[2] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 0)
            {
                if (Red[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Red[0], MovieMedia[redInteraction]));
                    StartCoroutine(disappear(Red[0]));

                    StartCoroutine(appear(Red[1]));
                    StartCoroutine(appear(Red[2]));

                    totInteraction++;
                    redInteraction++;

                    chronology[2] = "red";
                }
            }

            if (yellowInteraction == 2)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[5]));
                        StartCoroutine(appear(Yellow[6]));

                        StartCoroutine(disappear(Red[0]));
                        redInteraction = -1;

                        totInteraction++;
                        yellowInteraction++;

                        chronology[2] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 1)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[3]));
                        StartCoroutine(appear(Yellow[4]));

                        totInteraction++;
                        yellowInteraction++;

                        chronology[2] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 0)
            {
                if (Yellow[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Yellow[0], WebStarMedia[yellowInteraction]));
                    StartCoroutine(disappear(Yellow[0]));

                    StartCoroutine(appear(Yellow[1]));
                    StartCoroutine(appear(Yellow[2]));

                    totInteraction++;
                    yellowInteraction++;

                    chronology[2] = "yellow";
                }
            }

            if (greenInteraction == 2)
            {
                foreach (GameObject greenIcon in Yellow)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[5]));
                        StartCoroutine(appear(Green[6]));

                        StartCoroutine(disappear(Red[0]));
                        redInteraction = -1;

                        totInteraction++;
                        greenInteraction++;

                        chronology[2] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 1)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[3]));
                        StartCoroutine(appear(Green[4]));

                        totInteraction++;
                        greenInteraction++;

                        chronology[2] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 0)
            {
                if (Green[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Green[0], WebStarMedia[greenInteraction]));
                    StartCoroutine(disappear(Green[0]));

                    StartCoroutine(appear(Green[1]));
                    StartCoroutine(appear(Green[2]));

                    totInteraction++;
                    greenInteraction++;

                    chronology[2] = "green";
                }
            }
        }//fine terza interazione

        //inizio quarta interazione
        else if (totInteraction == 3)
        {
            if (blueInteraction == 3)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[7]));
                        StartCoroutine(appear(Blue[8]));
                        StartCoroutine(appear(Blue[9]));

                        StartCoroutine(disappear(Red[0]));

                        totInteraction++;
                        blueInteraction++;

                        chronology[3] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 2)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[5]));
                        StartCoroutine(appear(Blue[6]));
                        StartCoroutine(appear(Blue[7]));

                        if (redInteraction == 0)
                        {
                            StartCoroutine(disappear(Red[0]));
                            redInteraction = -1;
                        }
                        else if (yellowInteraction == 0)
                        {
                            StartCoroutine(disappear(Yellow[0]));
                            yellowInteraction = -1;
                        }

                        totInteraction++;
                        blueInteraction++;

                        chronology[3] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 1)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[3]));
                        StartCoroutine(appear(Blue[4]));
                        StartCoroutine(appear(Blue[5]));

                        //situazione in cui abbiamo 3 rossi, 3 verdi/gialli, 3 blu
                        //togliamo quello scelto più indietro
                        if (blueInteraction == 1 && redInteraction == 1 && (yellowInteraction == 1 || greenInteraction == 1))
                        {
                            if (chronology[0] != "blue")
                            {
                                if (chronology[0] == "red")
                                {
                                    foreach (GameObject redIcon in Red)
                                    {
                                        StartCoroutine(disappear(redIcon));
                                        redInteraction = -1;
                                    }
                                }
                                else if (chronology[0] == "yellow")
                                {
                                    foreach (GameObject yellowIcon in Yellow)
                                    {
                                        StartCoroutine(disappear(yellowIcon));
                                        yellowInteraction = -1;
                                    }
                                }
                                else if (chronology[0] == "green")
                                {
                                    foreach (GameObject greenIcon in Green)
                                    {
                                        StartCoroutine(disappear(greenIcon));
                                        greenInteraction = -1;
                                    }
                                }
                            }
                            else
                            {
                                if (chronology[1] == "red")
                                {
                                    foreach (GameObject redIcon in Red)
                                    {
                                        StartCoroutine(disappear(redIcon));
                                        redInteraction = -1;
                                    }
                                }
                                else if (chronology[1] == "yellow")
                                {
                                    foreach (GameObject yellowIcon in Yellow)
                                    {
                                        StartCoroutine(disappear(yellowIcon));
                                        yellowInteraction = -1;
                                    }
                                }
                                else if (chronology[1] == "green")
                                {
                                    foreach (GameObject greenIcon in Green)
                                    {
                                        StartCoroutine(disappear(greenIcon));
                                        greenInteraction = -1;
                                    }
                                }
                            }
                        }

                        //altra situazione in cui ci sono 5 rossi/verdi/gialli 3 blu e 1 rosso/giallo
                        else
                        {
                            if (redInteraction == 0)
                            {
                                StartCoroutine(disappear(Red[0]));
                                redInteraction = -1;
                            }
                            else
                            {
                                StartCoroutine(disappear(Yellow[0]));
                                yellowInteraction = -1;
                            }
                        }

                        totInteraction++;
                        blueInteraction++;

                        chronology[3] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 0)
            {
                if (Blue[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Blue[0], InformationMedia[blueInteraction]));
                    StartCoroutine(disappear(Blue[0]));

                    StartCoroutine(appear(Blue[1]));
                    StartCoroutine(appear(Blue[2]));
                    StartCoroutine(appear(Blue[3]));

                    if (redInteraction == 1)
                    {
                        foreach (GameObject redIcon in Red)
                        {
                            StartCoroutine(disappear(redIcon));
                            redInteraction = -1;
                        }
                    }
                    else if (yellowInteraction == 1)
                    {
                        foreach (GameObject yellowIcon in Red)
                        {
                            StartCoroutine(disappear(yellowIcon));
                            yellowInteraction = -1;
                        }
                    }
                    else if (greenInteraction == 1)
                    {
                        foreach (GameObject greenIcon in Green)
                        {
                            StartCoroutine(disappear(greenIcon));
                            yellowInteraction = -1;
                        }
                    }

                    totInteraction++;
                    blueInteraction++;

                    chronology[3] = "blue";
                }
            }

            if (redInteraction == 3)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[7]));
                        StartCoroutine(appear(Red[8]));
                        StartCoroutine(appear(Red[9]));

                        StartCoroutine(disappear(Blue[0]));

                        totInteraction++;
                        redInteraction++;

                        chronology[3] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 2)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[5]));
                        StartCoroutine(appear(Red[6]));
                        StartCoroutine(appear(Red[7]));

                        if (blueInteraction == 0)
                        {
                            StartCoroutine(disappear(Blue[0]));
                            blueInteraction = -1;
                        }
                        else if (yellowInteraction == 0)
                        {
                            StartCoroutine(disappear(Yellow[0]));
                            yellowInteraction = -1;
                        }

                        totInteraction++;
                        redInteraction++;

                        chronology[3] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 1)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[3]));
                        StartCoroutine(appear(Red[4]));
                        StartCoroutine(appear(Red[5]));

                        //situazione in cui abbiamo 3 rossi, 3 verdi/gialli, 3 blu
                        //togliamo quello scelto più indietro
                        if (blueInteraction == 1 && redInteraction == 1 && (yellowInteraction == 1 || greenInteraction == 1))
                        {
                            if (chronology[0] != "red")
                            {
                                if (chronology[0] == "blue")
                                {
                                    foreach (GameObject blueIcon in Blue)
                                    {
                                        StartCoroutine(disappear(blueIcon));
                                        redInteraction = -1;
                                    }
                                }
                                else if (chronology[0] == "yellow")
                                {
                                    foreach (GameObject yellowIcon in Yellow)
                                    {
                                        StartCoroutine(disappear(yellowIcon));
                                        yellowInteraction = -1;
                                    }
                                }
                                else if (chronology[0] == "green")
                                {
                                    foreach (GameObject greenIcon in Green)
                                    {
                                        StartCoroutine(disappear(greenIcon));
                                        greenInteraction = -1;
                                    }
                                }
                            }
                            else
                            {
                                if (chronology[1] == "blue")
                                {
                                    foreach (GameObject blueIcon in Blue)
                                    {
                                        StartCoroutine(disappear(blueIcon));
                                        blueInteraction = -1;
                                    }
                                }
                                else if (chronology[1] == "yellow")
                                {
                                    foreach (GameObject yellowIcon in Yellow)
                                    {
                                        StartCoroutine(disappear(yellowIcon));
                                        yellowInteraction = -1;
                                    }
                                }
                                else if (chronology[1] == "green")
                                {
                                    foreach (GameObject greenIcon in Green)
                                    {
                                        StartCoroutine(disappear(greenIcon));
                                        greenInteraction = -1;
                                    }
                                }
                            }
                        }

                        //altra situazione in cui ci sono 5 blu/verdi/gialli 3 rossi e 1 blu/giallo
                        else
                        {
                            if (blueInteraction == 0)
                            {
                                StartCoroutine(disappear(Blue[0]));
                                blueInteraction = -1;
                            }
                            else
                            {
                                StartCoroutine(disappear(Yellow[0]));
                                yellowInteraction = -1;
                            }
                        }

                        totInteraction++;
                        redInteraction++;

                        chronology[3] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 0)
            {
                if (Red[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Red[0], MovieMedia[redInteraction]));
                    StartCoroutine(disappear(Red[0]));

                    StartCoroutine(appear(Red[1]));
                    StartCoroutine(appear(Red[2]));
                    StartCoroutine(appear(Red[3]));


                    if (blueInteraction == 1)
                    {
                        foreach (GameObject blueIcon in Blue)
                        {
                            StartCoroutine(disappear(blueIcon));
                            blueInteraction = -1;
                        }
                    }
                    else if (yellowInteraction == 1)
                    {
                        foreach (GameObject yellowIcon in Red)
                        {
                            StartCoroutine(disappear(yellowIcon));
                            yellowInteraction = -1;
                        }
                    }
                    else if (greenInteraction == 1)
                    {
                        foreach (GameObject greenIcon in Green)
                        {
                            StartCoroutine(disappear(greenIcon));
                            yellowInteraction = -1;
                        }
                    }

                    totInteraction++;
                    redInteraction++;

                    chronology[3] = "red";
                }
            }

            if (yellowInteraction == 3)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[7]));
                        StartCoroutine(appear(Yellow[8]));
                        StartCoroutine(appear(Yellow[9]));

                        StartCoroutine(disappear(Blue[0]));

                        totInteraction++;
                        yellowInteraction++;

                        chronology[3] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 2)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[5]));
                        StartCoroutine(appear(Yellow[6]));
                        StartCoroutine(appear(Yellow[7]));

                        if (blueInteraction == 0)
                        {
                            StartCoroutine(disappear(Blue[0]));
                            blueInteraction = -1;
                        }
                        else if (redInteraction == 0)
                        {
                            StartCoroutine(disappear(Red[0]));
                            redInteraction = -1;
                        }

                        totInteraction++;
                        yellowInteraction++;

                        chronology[3] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 1)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[3]));
                        StartCoroutine(appear(Yellow[4]));
                        StartCoroutine(appear(Yellow[5]));

                        //situazione in cui abbiamo 3 rossi, 3 gialli, 3 blu
                        //togliamo quello scelto più indietro
                        if (blueInteraction == 1 && redInteraction == 1 && yellowInteraction == 1)
                        {
                            if (chronology[0] != "yellow")
                            {
                                if (chronology[0] == "blue")
                                {
                                    foreach (GameObject blueIcon in Blue)
                                    {
                                        StartCoroutine(disappear(blueIcon));
                                        blueInteraction = -1;
                                    }
                                }
                                else if (chronology[0] == "red")
                                {
                                    foreach (GameObject redIcon in Red)
                                    {
                                        StartCoroutine(disappear(redIcon));
                                        redInteraction = -1;
                                    }
                                }
                            }
                            else
                            {
                                if (chronology[1] == "blue")
                                {
                                    foreach (GameObject blueIcon in Blue)
                                    {
                                        StartCoroutine(disappear(blueIcon));
                                        blueInteraction = -1;
                                    }
                                }
                                else if (chronology[1] == "red")
                                {
                                    foreach (GameObject redIcon in Yellow)
                                    {
                                        StartCoroutine(disappear(redIcon));
                                        redInteraction = -1;
                                    }
                                }
                            }
                        }

                        //altra situazione in cui ci sono 5 blu/rossi 3 gialli e 1 blu/rosso
                        else
                        {
                            if (blueInteraction == 0)
                            {
                                StartCoroutine(disappear(Blue[0]));
                                blueInteraction = -1;
                            }
                            else
                            {
                                StartCoroutine(disappear(Red[0]));
                                redInteraction = -1;
                            }
                        }

                        totInteraction++;
                        yellowInteraction++;

                        chronology[3] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 0)
            {
                if (Yellow[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Yellow[0], WebStarMedia[yellowInteraction]));
                    StartCoroutine(disappear(Yellow[0]));

                    StartCoroutine(appear(Yellow[1]));
                    StartCoroutine(appear(Yellow[2]));
                    StartCoroutine(appear(Yellow[3]));

                    if (blueInteraction == 1)
                    {
                        foreach (GameObject blueIcon in Blue)
                        {
                            StartCoroutine(disappear(blueIcon));
                            blueInteraction = -1;
                        }
                    }
                    else if (redInteraction == 1)
                    {
                        foreach (GameObject redIcon in Red)
                        {
                            StartCoroutine(disappear(redIcon));
                            redInteraction = -1;
                        }
                    }

                    totInteraction++;
                    yellowInteraction++;

                    chronology[3] = "yellow";
                }
            }

            if (greenInteraction == 3)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[7]));
                        StartCoroutine(appear(Green[8]));
                        StartCoroutine(appear(Green[9]));

                        StartCoroutine(disappear(Blue[0]));

                        totInteraction++;
                        greenInteraction++;

                        chronology[3] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 2)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[5]));
                        StartCoroutine(appear(Green[6]));
                        StartCoroutine(appear(Green[7]));

                        if (blueInteraction == 0)
                        {
                            StartCoroutine(disappear(Blue[0]));
                            blueInteraction = -1;
                        }
                        else if (redInteraction == 0)
                        {
                            StartCoroutine(disappear(Red[0]));
                            redInteraction = -1;
                        }

                        totInteraction++;
                        greenInteraction++;

                        chronology[3] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 1)
            {
                foreach (GameObject greenIcon in Yellow)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Yellow[3]));
                        StartCoroutine(appear(Yellow[4]));
                        StartCoroutine(appear(Yellow[5]));

                        //situazione in cui abbiamo 3 rossi, 3 gialli, 3 blu
                        //togliamo quello scelto più indietro
                        if (blueInteraction == 1 && redInteraction == 1 && yellowInteraction == 1)
                        {
                            if (chronology[0] != "yellow")
                            {
                                if (chronology[0] == "blue")
                                {
                                    foreach (GameObject blueIcon in Blue)
                                    {
                                        StartCoroutine(disappear(blueIcon));
                                        blueInteraction = -1;
                                    }
                                }
                                else if (chronology[0] == "red")
                                {
                                    foreach (GameObject redIcon in Red)
                                    {
                                        StartCoroutine(disappear(redIcon));
                                        redInteraction = -1;
                                    }
                                }
                            }
                            else
                            {
                                if (chronology[1] == "blue")
                                {
                                    foreach (GameObject blueIcon in Blue)
                                    {
                                        StartCoroutine(disappear(blueIcon));
                                        blueInteraction = -1;
                                    }
                                }
                                else if (chronology[1] == "red")
                                {
                                    foreach (GameObject redIcon in Red)
                                    {
                                        StartCoroutine(disappear(redIcon));
                                        redInteraction = -1;
                                    }
                                }
                            }
                        }

                        //altra situazione in cui ci sono 5 blu/rossi 3 verdi e 1 blu/rosso
                        else
                        {
                            if (blueInteraction == 0)
                            {
                                StartCoroutine(disappear(Blue[0]));
                                blueInteraction = -1;
                            }
                            else
                            {
                                StartCoroutine(disappear(Red[0]));
                                redInteraction = -1;
                            }
                        }

                        totInteraction++;
                        greenInteraction++;

                        chronology[3] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 0)
            {
                if (Green[0].GetComponent<CheckInteraction>().collision)
                {
                    StartCoroutine(AssignMedia(Green[0], WebStarMedia[greenInteraction]));
                    StartCoroutine(disappear(Green[0]));

                    StartCoroutine(appear(Green[1]));
                    StartCoroutine(appear(Green[2]));
                    StartCoroutine(appear(Green[3]));

                    if (blueInteraction == 1)
                    {
                        foreach (GameObject blueIcon in Blue)
                        {
                            StartCoroutine(disappear(blueIcon));
                            blueInteraction = -1;
                        }
                    }
                    else if (redInteraction == 1)
                    {
                        foreach (GameObject redIcon in Red)
                        {
                            StartCoroutine(disappear(redIcon));
                            redInteraction = -1;
                        }
                    }

                    totInteraction++;
                    greenInteraction++;

                    chronology[3] = "green";
                }
            }
        }//fine quarta interazione

        //inizio quinta interazione
        else if (totInteraction == 4)
        {
            if (blueInteraction == 4)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[10]));
                        StartCoroutine(appear(Blue[11]));
                        StartCoroutine(appear(Blue[12]));

                        totInteraction++;
                        blueInteraction++;

                        chronology[4] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 3)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[8]));
                        StartCoroutine(appear(Blue[9]));
                        StartCoroutine(appear(Blue[10]));

                        //se è stato scelto due volte di fila blu che è nettamente superiore, togliamo l'altro colore rimanente
                        if (chronology[3] == "blue")
                        {
                            if (redInteraction == 1)
                            {
                                foreach (GameObject redIcon in Red)
                                {
                                    StartCoroutine(disappear(redIcon));
                                    redInteraction = -1;
                                }
                            }
                            else if (yellowInteraction == 1)
                            {
                                foreach (GameObject yellowIcon in Yellow)
                                {
                                    StartCoroutine(disappear(yellowIcon));
                                    yellowInteraction = -1;
                                }
                            }
                            else
                            {
                                foreach (GameObject greenIcon in Green)
                                {
                                    StartCoroutine(disappear(greenIcon));
                                    greenInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        blueInteraction++;

                        chronology[4] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 2)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[6]));
                        StartCoroutine(appear(Blue[7]));
                        StartCoroutine(appear(Blue[8]));

                        if (chronology[3] == "blue")
                        {
                            if (redInteraction != -1)
                            {
                                foreach (GameObject redIcon in Red)
                                {
                                    StartCoroutine(disappear(redIcon));
                                    redInteraction = -1;
                                }
                            }
                            else if (yellowInteraction != -1)
                            {
                                foreach (GameObject yellowIcon in Yellow)
                                {
                                    StartCoroutine(disappear(yellowIcon));
                                    yellowInteraction = -1;
                                }
                            }
                            else if (greenInteraction != -1)
                            {
                                foreach (GameObject greenIcon in Green)
                                {
                                    StartCoroutine(disappear(greenIcon));
                                    greenInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        blueInteraction++;

                        chronology[4] = "blue";
                        break;
                    }
                }
            }

            else if (blueInteraction == 1)
            {
                foreach (GameObject blueIcon in Blue)
                {
                    if (blueIcon.GetComponent<CheckInteraction>().collision && blueIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(blueIcon, InformationMedia[blueInteraction]));
                        StartCoroutine(disappear(blueIcon));

                        StartCoroutine(appear(Blue[4]));
                        StartCoroutine(appear(Blue[5]));
                        StartCoroutine(appear(Blue[6]));

                        totInteraction++;
                        blueInteraction++;

                        chronology[4] = "blue";
                        break;
                    }
                }
            }

            if (redInteraction == 4)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[10]));
                        StartCoroutine(appear(Red[11]));
                        StartCoroutine(appear(Red[12]));

                        totInteraction++;
                        redInteraction++;

                        chronology[4] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 3)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[8]));
                        StartCoroutine(appear(Red[9]));
                        StartCoroutine(appear(Red[10]));

                        //se è stato scelto due volte di fila rosso che è nettamente superiore, togliamo l'altro colore rimanente
                        if (chronology[3] == "red")
                        {
                            if (blueInteraction == 1)
                            {
                                foreach (GameObject blueIcon in Blue)
                                {
                                    StartCoroutine(disappear(blueIcon));
                                    blueInteraction = -1;
                                }
                            }
                            else if (yellowInteraction == 1)
                            {
                                foreach (GameObject yellowIcon in Yellow)
                                {
                                    StartCoroutine(disappear(yellowIcon));
                                    yellowInteraction = -1;
                                }
                            }
                            else
                            {
                                foreach (GameObject greenIcon in Green)
                                {
                                    StartCoroutine(disappear(greenIcon));
                                    greenInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        redInteraction++;

                        chronology[4] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 2)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[6]));
                        StartCoroutine(appear(Red[7]));
                        StartCoroutine(appear(Red[8]));

                        if (chronology[3] == "red")
                        {
                            if (blueInteraction != -1)
                            {
                                foreach (GameObject blueIcon in Blue)
                                {
                                    StartCoroutine(disappear(blueIcon));
                                    blueInteraction = -1;
                                }
                            }
                            else if (yellowInteraction != -1)
                            {
                                foreach (GameObject yellowIcon in Yellow)
                                {
                                    StartCoroutine(disappear(yellowIcon));
                                    yellowInteraction = -1;
                                }
                            }
                            else if (greenInteraction != -1)
                            {
                                foreach (GameObject greenIcon in Green)
                                {
                                    StartCoroutine(disappear(greenIcon));
                                    greenInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        redInteraction++;

                        chronology[4] = "red";
                        break;
                    }
                }
            }

            else if (redInteraction == 1)
            {
                foreach (GameObject redIcon in Red)
                {
                    if (redIcon.GetComponent<CheckInteraction>().collision && redIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(redIcon, MovieMedia[redInteraction]));
                        StartCoroutine(disappear(redIcon));

                        StartCoroutine(appear(Red[4]));
                        StartCoroutine(appear(Red[5]));
                        StartCoroutine(appear(Red[6]));

                        totInteraction++;
                        redInteraction++;

                        chronology[4] = "red";
                        break;
                    }
                }
            }

            if (yellowInteraction == 4)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[10]));
                        StartCoroutine(appear(Yellow[11]));
                        StartCoroutine(appear(Yellow[12]));

                        totInteraction++;
                        yellowInteraction++;

                        chronology[4] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 3)
            {
                foreach (GameObject yellowIcon in Red)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[8]));
                        StartCoroutine(appear(Yellow[9]));
                        StartCoroutine(appear(Yellow[10]));

                        //se è stato scelto due volte di fila giallo che è nettamente superiore, togliamo l'altro colore rimanente
                        if (chronology[3] == "yellow")
                        {
                            if (blueInteraction == 1)
                            {
                                foreach (GameObject blueIcon in Blue)
                                {
                                    StartCoroutine(disappear(blueIcon));
                                    blueInteraction = -1;
                                }
                            }
                            else if (redInteraction == 1)
                            {
                                foreach (GameObject redIcon in Red)
                                {
                                    StartCoroutine(disappear(redIcon));
                                    redInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        yellowInteraction++;

                        chronology[4] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 2)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[6]));
                        StartCoroutine(appear(Yellow[7]));
                        StartCoroutine(appear(Yellow[8]));

                        if (chronology[3] == "yellow")
                        {
                            if (blueInteraction != -1)
                            {
                                foreach (GameObject blueIcon in Blue)
                                {
                                    StartCoroutine(disappear(blueIcon));
                                    blueInteraction = -1;
                                }
                            }
                            else if (redInteraction != -1)
                            {
                                foreach (GameObject redIcon in Red)
                                {
                                    StartCoroutine(disappear(redIcon));
                                    redInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        yellowInteraction++;

                        chronology[4] = "yellow";
                        break;
                    }
                }
            }

            else if (yellowInteraction == 1)
            {
                foreach (GameObject yellowIcon in Yellow)
                {
                    if (yellowIcon.GetComponent<CheckInteraction>().collision && yellowIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(yellowIcon, WebStarMedia[yellowInteraction]));
                        StartCoroutine(disappear(yellowIcon));

                        StartCoroutine(appear(Yellow[4]));
                        StartCoroutine(appear(Yellow[5]));
                        StartCoroutine(appear(Yellow[6]));

                        totInteraction++;
                        yellowInteraction++;

                        chronology[4] = "yellow";
                        break;
                    }
                }
            }

            if (greenInteraction == 4)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[10]));
                        StartCoroutine(appear(Green[11]));
                        StartCoroutine(appear(Green[12]));

                        totInteraction++;
                        greenInteraction++;

                        chronology[4] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 3)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[8]));
                        StartCoroutine(appear(Green[9]));
                        StartCoroutine(appear(Green[10]));

                        //se è stato scelto due volte di fila giallo che è nettamente superiore, togliamo l'altro colore rimanente
                        if (chronology[3] == "green")
                        {
                            if (blueInteraction == 1)
                            {
                                foreach (GameObject blueIcon in Blue)
                                {
                                    StartCoroutine(disappear(blueIcon));
                                    blueInteraction = -1;
                                }
                            }
                            else if (redInteraction == 1)
                            {
                                foreach (GameObject redIcon in Red)
                                {
                                    StartCoroutine(disappear(redIcon));
                                    redInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        greenInteraction++;

                        chronology[4] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 2)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[6]));
                        StartCoroutine(appear(Green[7]));
                        StartCoroutine(appear(Green[8]));

                        if (chronology[3] == "green")
                        {
                            if (blueInteraction != -1)
                            {
                                foreach (GameObject blueIcon in Blue)
                                {
                                    StartCoroutine(disappear(blueIcon));
                                    blueInteraction = -1;
                                }
                            }
                            else if (redInteraction != -1)
                            {
                                foreach (GameObject redIcon in Red)
                                {
                                    StartCoroutine(disappear(redIcon));
                                    redInteraction = -1;
                                }
                            }
                        }

                        totInteraction++;
                        greenInteraction++;

                        chronology[4] = "green";
                        break;
                    }
                }
            }

            else if (greenInteraction == 1)
            {
                foreach (GameObject greenIcon in Green)
                {
                    if (greenIcon.GetComponent<CheckInteraction>().collision && greenIcon.GetComponent<SphereCollider>().enabled)
                    {
                        StartCoroutine(AssignMedia(greenIcon, WebStarMedia[greenInteraction]));
                        StartCoroutine(disappear(greenIcon));

                        StartCoroutine(appear(Green[4]));
                        StartCoroutine(appear(Green[5]));
                        StartCoroutine(appear(Green[6]));

                        totInteraction++;
                        greenInteraction++;

                        chronology[4] = "green";
                        break;
                    }
                }
            }
        }//fine quinta interazione

        crr = 1;
    }

    //Coroutine per far sparire l'icona
    IEnumerator disappear(GameObject icon)
    {
        icon.GetComponentInChildren<ParticleSystem>().Play();

        icon.GetComponent<MeshCollider>().enabled = false;
        icon.GetComponent<MeshCollider>().isTrigger = false;

        yield return new WaitForSeconds(.1f); //per feedback su controller

        //va inserita l'animazione della sparizione, si potrebbe usare un bool associato all'animazione poi per far partire
        //la sparizione di Collider e Render
        //comunque vanno tolti Render e Collider per diminuire il peso grafico

        icon.GetComponent<MeshRenderer>().enabled = false;
    }

    //Coroutine per far apparire l'icona
    IEnumerator appear(GameObject icon)
    {
        if (icon.TryGetComponent(out EvenParticlesAttraction even))
        {
            while (icon.GetComponent<EvenParticlesAttraction>().creation == false)
            {
                yield return new WaitForSeconds(2);
            }
            print(icon.GetComponentInChildren<ParticleSystem>());
            icon.GetComponentInChildren<ParticleSystem>().Play();

            yield return new WaitForSeconds(3f);

            //va inserita l'animazione dell'apparizione, si potrebbe usare un bool associato all'animazione poi per far partire
            //l'apparizione di Collider e Render

            icon.GetComponent<MeshRenderer>().enabled = true;
            icon.GetComponent<MeshCollider>().enabled = true;
        }
        else if (icon.TryGetComponent(out OddParticlesAttraction odd))
        {
            while (icon.GetComponent<OddParticlesAttraction>().creation == false)
            {
                yield return new WaitForSeconds(2);
            }
            print(icon.GetComponentInChildren<ParticleSystem>());
            icon.GetComponentInChildren<ParticleSystem>().Play();

            yield return new WaitForSeconds(3f);

            //va inserita l'animazione dell'apparizione, si potrebbe usare un bool associato all'animazione poi per far partire
            //l'apparizione di Collider e Render

            icon.GetComponent<MeshRenderer>().enabled = true;
            icon.GetComponent<MeshCollider>().enabled = true;
        }
    }

    //per ordinare gli array di icone
    private GameObject[] sortArray(GameObject[] icons, int i)
    {
        GameObject[] sorted = new GameObject[i];

        foreach(GameObject icon in icons)
        {
            string name = icon.name;
            int number = System.Int32.Parse(Regex.Match(name, @"\d+").Value);

            sorted[number - 1] = icon;
        }

        return sorted;
    }

    IEnumerator AssignMedia(GameObject icon, GameObject media)
    {
        yield return new WaitForSeconds(1);

        media.transform.position = new Vector3(icon.transform.position.x, icon.transform.position.y, icon.transform.position.z);

        //per video
        if (media.TryGetComponent(out MeshRenderer renderVideo) && media.TryGetComponent(out VideoPlayer player))
        {
            renderVideo.enabled = true;
            player.Play();
        }

        //per immagini
        else if(media.TryGetComponent(out MeshRenderer renderImage))
            renderImage.enabled = true;
        
        //per audio
        else if(media.TryGetComponent(out AudioSource audioSource))
            audioSource.Play();
       
    }
}
