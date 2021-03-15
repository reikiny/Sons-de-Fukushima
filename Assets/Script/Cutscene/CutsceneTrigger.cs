using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    private PlayableDirector timeline;

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timeline.Play();
        }
    }
}
