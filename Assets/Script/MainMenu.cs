using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string cena;
    public float tempoDeEspera;

    public void LoadScene(){
        SceneManager.LoadScene(cena);
    }

    public void Quit(){
        Application.Quit();
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(tempoDeEspera);
        
    }
}
