using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiente : MonoBehaviour
{
    public AudioClip ambient;
    AudioSource source;
    int nmr;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Chamar();
    }

    IEnumerator tempo()
    {
        nmr = Random.Range(1, 3);
        if (nmr == 1)
            source.PlayOneShot(ambient);
        yield return new WaitForSeconds(ambient.length);
        Chamar();
    }
    void Chamar()
    {
        StartCoroutine(tempo());
    }
}
