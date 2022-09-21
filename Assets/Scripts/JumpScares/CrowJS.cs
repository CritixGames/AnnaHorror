using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowJS : MonoBehaviour
{

    public AudioClip crowSFX;
    [SerializeField] [Range(0f,1f)] float ScareVolume = 1f;
    public bool crowBool = false;

    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player" && crowBool == false)
        {
            PlayClip(crowSFX, ScareVolume);
            crowBool = true;
        }
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
