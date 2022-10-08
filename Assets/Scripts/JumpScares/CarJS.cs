using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarJS : MonoBehaviour
{

    public AudioClip carSFX;
    [SerializeField][Range(0f, 1f)] float ScareVolume = 1f;
    public bool carBool = false;
    public GameObject carLights;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && carBool == false)
        {
            PlayClip(carSFX, ScareVolume);
            carBool = true;
            StartCoroutine(Fade(carLights, 1f));
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

    public IEnumerator Fade(GameObject obj, float seconds)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);

    }
}
