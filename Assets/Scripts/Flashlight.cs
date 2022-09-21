using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    // if freese == true, then player can't turn on/off their flashlights anymore.
    public bool freeze = false;

    // singleton code for easy access across all the other scripts
    // (TODO: I am not sure whether this is still a good way to code if we have different scenes. But I dont foresee any big problems yet.)
    private static Flashlight instance;
    public static Flashlight Instance { get => instance; }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // end of singelton code

    void Start()
    {
        off = true;
        flashlight.SetActive(false);
    }

    void Update()
    {
        if (freeze)
        {
            return;
        }


        if(off && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }

    }


    public void TurnOffFlashlightNoSound()
    {
        flashlight.SetActive(false);
        off = true;
        on = false;
    }
}
