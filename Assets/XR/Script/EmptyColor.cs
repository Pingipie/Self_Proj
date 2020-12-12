using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyColor : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    public int blueInteraction;
    public int redInteraction;
    public int yellowInteraction;
    public int greenInteraction;

    public ParticleSystem ps1;
    public ParticleSystem ps2;

    Color Blue;
    Color Red;
    Color Yellow;
    Color Green;

    int changeColor;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        Blue = new Color(0, 16f / 255f, 1);
        Red = new Color(1, 13f / 255f, 0);
        Yellow = new Color(230f / 255f, 233f / 255f, 0);
        Green = new Color(7f / 255f, 233f / 255f, 0);

        blueInteraction = -1;
        redInteraction = -1;
        yellowInteraction = -1;
        greenInteraction = -1;

        changeColor = 0;
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 1) 
            ColorTunnel();
    }

    private void ColorTunnel()
    {
        counter = 0;
        if (blueInteraction != -1)
        {
            if (redInteraction != -1)
            {
                if (blueInteraction == redInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Blue;
                    main = ps2.main;
                    main.startColor = Red;
                }

                else if (blueInteraction > redInteraction)
                {
                    var main = ps1.main;
                    main.startColor = new ParticleSystem.MinMaxGradient(Blue);
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Red;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Blue;
                            changeColor = 0;
                        }

                    }
                }

                else if (blueInteraction < redInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Red;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Red;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Blue;
                            changeColor = 0;
                        }

                    }
                }
            }

            else if (yellowInteraction != -1)
            {
                if (blueInteraction == yellowInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Blue;
                    main = ps2.main;
                    main.startColor = Yellow;
                }

                else if (blueInteraction > yellowInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Blue;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Yellow;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Blue;
                            changeColor = 0;
                        }

                    }
                }

                else if (blueInteraction < yellowInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Yellow;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Yellow;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Blue;
                            changeColor = 0;
                        }

                    }
                }
            }

            else if (greenInteraction != -1)
            {
                if (blueInteraction == greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Blue;
                    main = ps2.main;
                    main.startColor = Green;
                }

                else if (blueInteraction > greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Blue;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Green;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Blue;
                            changeColor = 0;
                        }

                    }
                }

                else if (blueInteraction < greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Green;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Green;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Blue;
                            changeColor = 0;
                        }

                    }
                }
            }
            else
            {
                var main = ps1.main;
                main.startColor = Blue;
                main = ps2.main;
                main.startColor = Blue;
            }
        }

        else if (redInteraction != -1)
        {
            if (yellowInteraction != -1)
            {
                if (yellowInteraction == redInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Yellow;
                    main = ps2.main;
                    main.startColor = Red;
                }

                else if (yellowInteraction > redInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Yellow;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Red;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Yellow;
                            changeColor = 0;
                        }

                    }
                }

                else if (yellowInteraction <redInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Red;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Red;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Yellow;
                            changeColor = 0;
                        }

                    }
                }
            }

            else if (greenInteraction != -1)
            {
                if (redInteraction == greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Red;
                    main = ps2.main;
                    main.startColor = Green;
                }

                else if (redInteraction > greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Red;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Green;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Red;
                            changeColor = 0;
                        }

                    }
                }

                else if (redInteraction < greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Green;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Green;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Red;
                            changeColor = 0;
                        }

                    }
                }
            }

            else
            {
                var main = ps1.main;
                main.startColor = Red;
                main = ps2.main;
                main.startColor = Red;
            }
        }

        else if (yellowInteraction != -1)
        {
            if (greenInteraction != -1)
            {
                if (yellowInteraction == greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Yellow;
                    main = ps2.main;
                    main.startColor = Green;
                }

                else if (yellowInteraction > greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Yellow;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Green;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Yellow;
                            changeColor = 0;
                        }

                    }
                }

                else if (yellowInteraction < greenInteraction)
                {
                    var main = ps1.main;
                    main.startColor = Green;
                    main = ps2.main;
                    while (counter == 1)
                    {
                        if (changeColor == 0)
                        {
                            main.startColor = Green;
                            changeColor = 1;
                        }
                        else
                        {
                            main.startColor = Yellow;
                            changeColor = 0;
                        }

                    }
                }
            }

            else
            {
                var main = ps1.main;
                main.startColor = Yellow;
                main = ps2.main;
                main.startColor = Yellow;
            }
        }

        else if (greenInteraction != -1)
        {
            var main = ps1.main;
            main.startColor = Green;
            main = ps2.main;
            main.startColor = Green;
        }
    
        counter = 1;
    }
}
