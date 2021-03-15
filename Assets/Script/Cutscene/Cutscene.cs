using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    public static Cutscene current;
    public float id;   
    public PlayableDirector timeline;
    private BoxCollider boxCollider;


    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        chamar += cut;
        boxCollider = GetComponent<BoxCollider>();
    }
    public Action<int> chamar;
    void cut(int id)
    {
        if (id == this.id)
        {
            timeline.Play();
            boxCollider.enabled = !boxCollider.enabled;
        }
        
    }
   
    public void chamaCut(int id)
    {
        chamar?.Invoke(id);
    }
}
