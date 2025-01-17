﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelOut : MonoBehaviour
{
    GameObject Algorithm;
    GameObject mirrorEmpty;
    GameObject merchEmpty;
    GameObject colliderEmpty;
    GameObject blackSphereFade;
    GameObject Light;
    GameObject avatar;
    GameObject emptyAvatar;
    GameObject emptyPhone;
    GameObject vrRig;

    public GameObject emptyColor;

    Algorithm algorithm;

    int counter;

    int totInteraction;
    int blueInteraction;
    int redInteraction;
    int yellowInteraction;
    int greenInteraction;

    int nM;
    int nC;

    bool glitchB;
    bool time;
    bool mirrorEx;

    public int transition;

    // Start is called before the first frame update
    void Start()
    {
        transition = 0;
        counter = 0;

        mirrorEmpty = GameObject.Find("Mirror");
        blackSphereFade = GameObject.Find("FadeSphereBlack");
        avatar = GameObject.Find("Avatar_Cube");
        emptyAvatar = GameObject.Find("AVATARnfb");
        vrRig = GameObject.Find("VR Rig");

        glitchB = false;
        time = false;
        mirrorEx = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Algorithm") != null)
        {
            mirrorEmpty.transform.GetChild(2).gameObject.SetActive(true);
            avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
        }

        else
        {
            mirrorEmpty.transform.GetChild(2).gameObject.SetActive(false);
        }

        if (GameObject.Find("Algorithm") != null && Algorithm == null)
        {
            Algorithm = GameObject.Find("Algorithm");
            vrRig.transform.position = new Vector3(vrRig.transform.position.x, vrRig.transform.position.y, 3.36f);     
        }


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
            StartCoroutine(changeSkin());
        }

        if(GameObject.Find("Fade") != null && mirrorEx == false)
        {
            mirrorEmpty.transform.GetChild(0).gameObject.SetActive(true);
            mirrorEmpty.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            mirrorEmpty.transform.GetChild(0).gameObject.SetActive(false);
            mirrorEmpty.transform.GetChild(1).gameObject.SetActive(false);
        }

        if(GameObject.Find("Fade") != null && totInteraction == 5 && merchEmpty == null && colliderEmpty == null)
        {
            merchEmpty = GameObject.Find("Merchandising");
            emptyPhone = GameObject.Find("Phone");
            Destroy(emptyPhone.transform.GetChild(0).gameObject.GetComponent<CollisionDetector>());


            nM = merchEmpty.transform.childCount;

            for(int i = 0; i < nM; i++)
            {
                merchEmpty.transform.GetChild(i).gameObject.SetActive(true);
            }

            colliderEmpty = GameObject.Find("ColliderRaggi");

       
            nC = colliderEmpty.transform.childCount;
            
            for(int j = 0; j < nC; j++)
            {
                colliderEmpty.transform.GetChild(j).gameObject.SetActive(true);
            }
        }

        if(merchEmpty != null && colliderEmpty != null && glitchB == false)
        {
            glitchB = true;
            StartCoroutine(glitch());
        }

    }

    IEnumerator glitch()
    {
        if (time == false) {
            yield return new WaitForSeconds(30);
            time = true;
        }

        mirrorEmpty.transform.GetChild(0).gameObject.AddComponent<RaycastTelephone>();

        if (mirrorEmpty.transform.GetChild(0).gameObject.GetComponent<RaycastTelephone>().ray == true)
        {

            if (mirrorEmpty.transform.GetChild(0).gameObject.GetComponent<RaycastTelephone>().hit.collider.name == "carlo")
            {
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(true);
                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 0f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(true);
                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 0f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(true);
                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 0f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(true);
                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 0f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(true);
                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 0f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 1f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(true);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(true);
                yield return new WaitForSeconds(.5f);
                avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", 0f);
                emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
                emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

                mirrorEx = true;
                mirrorEmpty.transform.GetChild(3).gameObject.SetActive(true);

                yield return new WaitForSeconds(10);

                SceneManager.UnloadSceneAsync("Scena_Fuori");
                SceneManager.UnloadSceneAsync("Scena_XR");
            }
            else
                glitchB = false;
        }
        else
            glitchB = false;
    }

    IEnumerator changeSkin()
    {
        float i = 0;

        while (i < 1.001f)
        {
            avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", i);
            i += .01f;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Tunnel()
    {
        yield return new WaitForSeconds(60);

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

        float i = 1;

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

        emptyAvatar.transform.GetChild(1).gameObject.SetActive(false);
        emptyAvatar.transform.GetChild(2).gameObject.SetActive(false);
        emptyAvatar.transform.GetChild(3).gameObject.SetActive(false);
        emptyAvatar.transform.GetChild(4).gameObject.SetActive(false);
        emptyAvatar.transform.GetChild(5).gameObject.SetActive(false);
        emptyAvatar.transform.GetChild(6).gameObject.SetActive(false);

        while (i > 0.001f)
        {
            avatar.GetComponent<Renderer>().material.SetFloat("Vector1_1FB37F84", i);
            i -= .01f;
            yield return new WaitForSeconds(.1f);
        }
    }
}
