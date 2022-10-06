using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpNo : MonoBehaviour
{
    public static bool pressed = false;
    public GameObject noText;
    public AudioSource noSound;
    public GameObject otherButton1;
    public GameObject Ethan;

    public bool inReach3;


    void Start()
    {
        inReach3 = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && pressed == false)
        {
            inReach3 = true;
            noText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach3 = false;
            noText.SetActive(false);
        }
    }


    void Update()
    {

        if (inReach3 && Input.GetButtonDown("Interact") && pressed == false)
        {
            Noing();
        }


    }
    void Noing()
    {
        Debug.Log("Guess the gym is my friend now");
        noSound.Play();
        pressed = true;
        noText.SetActive(false);
        otherButton1.SetActive(false);
        Ethan.SetActive(true);
    }

}
