using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpYes : MonoBehaviour
{
    public static bool pressed = false;
    public GameObject yesText;
    public AudioSource yesSound;
    public GameObject otherButton;

    public GameObject Firework;
    public GameObject Firework1;
    public GameObject Firework2;
    public GameObject Firework3;
    public GameObject Firework4;
    public GameObject Firework5;

    public bool inReach2;


    void Start()
    {
        inReach2 = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && pressed == false)
        {
            inReach2 = true;
            yesText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach2 = false;
            yesText.SetActive(false);
        }
    }


    void Update()
    {

        if (inReach2 && Input.GetButtonDown("Interact") && pressed == false)
        {
            Yesing();
        }

    }
    void Yesing()
    {
        Debug.Log("She Said Yes :D");
        yesSound.Play();
        pressed = true;
        yesText.SetActive(false);
        otherButton.SetActive(false);
        Firework.GetComponent<ParticleSystem>().Play();
        Firework1.GetComponent<ParticleSystem>().Play();
    }

}

