using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

//using UnityEngine.Audio;

public enum interativo
{
    nada,
    objetos,
    porta,
    portaAberta,
    Cutscene,
    objectosRotacao,
    objectosNaoroda,
    ultimaCutscene
}

public class objeto : MonoBehaviour
{
    public interativo _interativo;
    [SerializeField] private string selectableTag = "Selectable";
    public int id;
    private Transform _selection;
    private bool vai;
    private TextoDoObjeto _TextoDoObjeto;
   
    private void Update()
    {
        _TextoDoObjeto = GetComponent<TextoDoObjeto>();
        raycast();
    }
    void raycast()
    {
        if (_selection != null)
        {
            ObjectEvent.current.withoutHighLight(id);
            _selection = null;
            _interativo = interativo.nada;
            _TextoDoObjeto.noAction?.Invoke();
            id = 0;
            vai = false;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit,2))
        {
            Debug.DrawLine(ray.origin, hit.point);
            var selection = hit.transform;
            if (selection.gameObject.CompareTag(selectableTag) && _interativo == interativo.nada)
            {

                id = selection.gameObject.GetComponent<EnumGlobal>()._id;
                _interativo = selection.gameObject.GetComponent<EnumGlobal>()._interativo;
                _TextoDoObjeto.action?.Invoke(); 
                _selection = selection;
            }

        }
        switch (_interativo)
        {
            case interativo.objetos:
                
                ObjectEvent.current.withHighLight(id);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ObjectEvent.current.fazerAlgo(id);
                }
                break;
            case interativo.porta:
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameEvents.current.DoorwayTriggerEnter(id);           
                }
                break;
            case interativo.portaAberta:


                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameEvents.current.DoorwayTriggerExit(id);
                }
                break;
            case interativo.Cutscene:


                if (Input.GetKeyDown(KeyCode.E))
                {
                    Cutscene.current.chamaCut(id);
                    
                }
                break;
            case interativo.objectosRotacao:


                if (Input.GetKeyDown(KeyCode.E))
                {
                    ObjectEvent.current.rotacionar(id);
                    
                }
                break; 
            case interativo.objectosNaoroda:

                ObjectEvent.current.withHighLight(id);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ObjectEvent.current.NaoRotacionar(id);
                    
                }
                break; 
            case interativo.ultimaCutscene:

               
                if (Input.GetKeyDown(KeyCode.E))
                {
                    loadEvets.current.chamar();
                    
                }
                break;
            default:
                break;
        }
    }
    
}
        
