using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public string Loads;
    public GameObject fpsController;
    public GameObject[] Desligar;
    public int id;
    private void Start()
    {
        fpsController = GameObject.Find("FPSCharacter");
    }
    void Deload(int id)
    {
        if (id == this.id)
        {
            SceneManager.MoveGameObjectToScene(fpsController.gameObject, SceneManager.GetSceneByName(Loads));
            for (int i = 0; i < Desligar.Length; i++)
            {
                Desligar[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

                Deload(id);

            
        }
    }
}
