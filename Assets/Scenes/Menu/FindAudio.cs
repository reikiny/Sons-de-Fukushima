using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAudio : MonoBehaviour
{
   public void Play(AudioClip audio){
       FindObjectOfType<KeepPlaying>().Tocar(audio);
   }
}
