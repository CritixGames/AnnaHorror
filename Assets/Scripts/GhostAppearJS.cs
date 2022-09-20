using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppearJS : MonoBehaviour
{
    public GameObject ghost;
    public AudioClip woodcrackSFX;
    [SerializeField][Range(0f, 1f)] float ScareVolume = 1f;
    public bool ghostbool1 = false;
    [SerializeField] int timer;


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && ghostbool1 == false)
        {
            PlayClip(woodcrackSFX, ScareVolume);
            ghostbool1 = true;
            SetActive(ghost);

            StartCoroutine(passiveMe(timer));
        }
    }

    void SetActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(ghost);
    }

    //void SetFalse(GameObject obj)
    //{
    //    Destroy(ghost);
    //}

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }

    }
}