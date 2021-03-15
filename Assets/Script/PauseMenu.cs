using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public string cena;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Controller.m_IsPaused)
            {
                Resume();
            }else
            {            
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Controller.m_IsPaused = !Controller.m_IsPaused;
        
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Controller.m_IsPaused = !Controller.m_IsPaused;
         
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(cena);
    }

    
}
