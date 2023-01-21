using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockJS : MonoBehaviour
{
    public AudioClip knockSFX;
    [SerializeField][Range(0f, 1f)] float ScareVolume = 1f;

    void Start()
    {
        StartCoroutine(waitBeforeKnock());
    }

    public IEnumerator waitBeforeKnock()
    {
        yield return new WaitForSeconds(15f);
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(knockSFX, cameraPos, ScareVolume);
    }

}
