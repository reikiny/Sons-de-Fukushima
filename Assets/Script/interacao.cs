using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class interacao : MonoBehaviour
{

    Vector3 ultimoFrame;
    bool agir;
    bool triggered;
    public GameObject botaoDeInterecao; // aparecer o botão de interação.
    public Camera inspeciona; // Para refênciar a segunda camera.
    //public GameObject cameraPrincipal; // Desliga o script da camera.
                                   // public GameObject cameraPrincipal;
   // public GameObject cameraInspecao;


    // Start is called before the first frame update
    void Start()
    {
        //cameraPrincipal.GetComponent<camera>();
        //cameraInspecao.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Interativo") 
        {
            botaoDeInterecao.SetActive(true);
            triggered = true;
            

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interativo") 
        {
            botaoDeInterecao.SetActive(false);
           // agir = false;

          /*  if (other.gameObject.tag == "Interativo" && Input.GetKeyUp(KeyCode.E))
            {
                agir = false;
            } */


        }
    }

    void Update()
    {

        interagir();
        print(agir);
         
          if (triggered == true && Input.GetKey(KeyCode.E))
        {
           // cameraInspecao.SetActive(true);
            agir = true;
           // cameraPrincipal.SetActive(false);
           // cameraPrincipal.enabled = !cameraPrincipal.enabled; // destiva o script da camera 
        } 

          if (triggered == true && Input.GetKey(KeyCode.R))
        {
           // cameraInspecao.SetActive(false);
            agir = false;
            //cameraPrincipal.SetActive(true);
           // cameraPrincipal.enabled = true;

        } 
    }

    void interagir() 
    {
        if (Input.GetMouseButtonDown(0) && agir == true)
        {
            ultimoFrame = Input.mousePosition;
            print(agir);
        }

        if (Input.GetMouseButton(0) && agir == true)
        {
            var delta = Input.mousePosition - ultimoFrame;
            ultimoFrame = Input.mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
            
            
        }

       // print(agir);
    }
}
