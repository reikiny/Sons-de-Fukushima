using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public CharacterController character; // Posição atual agachado.
    public KeyCode Key;
    public GameObject player; // Player
    public GameObject uicamera; // Segunda Camera
    float rotationY;
   
    void Update()
    {
        Agachar();
        followplayerrotation();


    }

    void Agachar()
    {
        // Agachar 

        if (Input.GetKeyDown(Key))
        {
            character.height = 1f;
        }

        if (Input.GetKeyUp(Key))
        {
            character.height = 2f;
        }
    }
     void followplayerrotation() // Rotaciona junto com a camera Principal  Eixo Y
    {
       rotationY = player.transform.eulerAngles.y;
        uicamera.transform.eulerAngles = new Vector3(uicamera.transform.eulerAngles.x, rotationY, uicamera.transform.eulerAngles.z);  
        
        
        //  uicamera.rotation.y = player.rotation.y;
    }
    
}
