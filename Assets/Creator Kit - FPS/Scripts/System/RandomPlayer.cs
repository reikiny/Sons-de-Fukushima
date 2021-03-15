using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TiposDeChao{Corredor, Madeira, Terra};
[RequireComponent(typeof(AudioSource))]

public class RandomPlayer : MonoBehaviour
{
    public AudioClip[] Clips;
    public AudioClip[] Clips_wood;
     public AudioClip[] Clips_dirt;
    public float PitchMin = 1.0f;
    public float PitchMax = 1.0f;
    public TiposDeChao tipos;
    public AudioSource source => m_Source;
    AudioSource m_Source;

    void Awake()
    {
        m_Source = GetComponent<AudioSource>();
    }

    public AudioClip GetRandomClip()
    {
        if(tipos == TiposDeChao.Madeira){
            return Clips_wood[Random.Range(0, Clips_wood.Length)];
        }else if(tipos == TiposDeChao.Corredor){
            return Clips[Random.Range(0, Clips.Length)];
        }else{
            return Clips_dirt[Random.Range(0, Clips_dirt.Length)];
        }
        
    }

    public void PlayRandom()
    {

        if(Clips.Length == 0)
            return;
        
        PlayClip(GetRandomClip(), PitchMin, PitchMax);
    }

    public void PlayClip(AudioClip clip, float pitchMin, float pitchMax)
    {
        m_Source.pitch = Random.Range(pitchMin, pitchMax);
        m_Source.PlayOneShot(clip);
    }
}
