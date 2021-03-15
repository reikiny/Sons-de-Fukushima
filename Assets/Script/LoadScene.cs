using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject[] ligar;
    public int id;
    void Deload(int id)
    {
        if (id == this.id)
        {
            for (int i = 0; i < ligar.Length; i++)
            {
                ligar[i].SetActive(true);
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
