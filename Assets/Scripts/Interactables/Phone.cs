using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public bool called = false;
    public GameObject phoneText;
    public AudioSource phoneSound;

    public bool inReach1;


    void Start()
    {
        inReach1 = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && called == false)
        {
            inReach1 = true;
            phoneText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach1 = false;
            phoneText.SetActive(false);
        }
    }


    void Update()
    {

        if (inReach1 && Input.GetButtonDown("Interact") && called == false)
        {
            Calling();
        }


    }
    void Calling()
    {
        Debug.Log("Calling...");
        phoneSound.Play();
        called = true;
        phoneText.SetActive(false);
    }

}
