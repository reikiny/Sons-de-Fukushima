using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
[CreateAssetMenu(fileName = "Dialoguo", menuName = "Legenda")]

public class Legenda: ScriptableObject
{
    public string audioName;
    public AudioClip audio;

    [TextArea]
    public string subtitle;

}



