using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppearJS : MonoBehaviour
{
    [Header("Ghost Prefab")]
    public GameObject ghost;

    [Header("Sound")]
    public AudioClip woodcrackSFX;
    [SerializeField][Range(0f, 1f)] float ScareVolume = 1f;


    [Header("Metadata")]
    public bool ghostbool1 = false;
    [SerializeField] float timer;


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && ghostbool1 == false)
        {
            PlayClip(woodcrackSFX, ScareVolume);
            ghostbool1 = true;
            SetActive(ghost);

            // play different effects here
            StartCoroutine(RemoveGhost(timer));
            // disable player's flashlight
            StartCoroutine(DisableFlashlight(timer));
            // do some flashy environment lighting, need to null check because not all ghost JS will necessarily trigger FlashyLightEffect.
            if(GetComponent<FlashyLightHelper>() != null)
                StartCoroutine(GetComponent<FlashyLightHelper>().FlashyLightEffect(timer));
        }
    }

    void SetActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    // turn off the ghost when the timer elapses
    IEnumerator RemoveGhost(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(ghost);
    }

    // funciton to turn off the player's flashlight, freeze it, and unfreeze when the timer elapses
    IEnumerator DisableFlashlight(float secs)
    {
        Flashlight.Instance.TurnOffFlashlightNoSound();
        Flashlight.Instance.freeze = true;
        yield return new WaitForSeconds(secs);
        Flashlight.Instance.freeze = false;
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}