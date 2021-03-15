using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlaying : MonoBehaviour
{
    
    private static KeepPlaying instance = null;
    public static KeepPlaying Instance{
        get {return instance;}
    }
    void Awake(){
        
        if(instance !=null && instance !=this){
            Destroy(this.gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    public void Tocar(AudioClip clip){
        GetComponent<AudioSource>().clip = clip;
         GetComponent<AudioSource>().Play();
    }

}
