using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Animator door1;
    public GameObject openText1;
    public GameObject blackScreen;
    public AudioSource doorSound1;


    public bool inReach1;




    void Start()
    {
        inReach1 = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach1 = true;
            openText1.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach1 = false;
            openText1.SetActive(false);
        }
    }





    void Update()
    {

        if (inReach1 && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }

    }
    void DoorOpens ()
    {
        Debug.Log("It Opens");
        door1.SetBool("Open", true);
        door1.SetBool("Closed", false);
        doorSound1.Play();
        blackScreen.SetActive(true);

    }


}
