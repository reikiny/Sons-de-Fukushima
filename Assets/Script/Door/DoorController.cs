using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(EnumGlobal))]
public class DoorController : MonoBehaviour
{
    
    public int id;
    private Vector3 endValue;
    public Transform target;
    private Vector3 startValue;
    public float duracao;
    private EnumGlobal enumGlobal;

    public AudioClip close;
    public AudioClip open;
    AudioSource source;


    private void Start()
    {
        endValue = target.position;
        startValue = transform.position;
        enumGlobal =GetComponent<EnumGlobal>();
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
        source = GetComponent<AudioSource>();
    }


    void OnDoorwayOpen(int id)
    {
            if (id == this.id)
            {
                transform.DOMove(endValue, duracao);
                enumGlobal._interativo = interativo.portaAberta;
                source.PlayOneShot(open);
            }
    }

    void OnDoorwayClose(int id)
    {
            if (id == this.id)
            {
                transform.DOMove(startValue, duracao);
                enumGlobal._interativo = interativo.porta;
                  source.PlayOneShot(close);
            }
    }
}
