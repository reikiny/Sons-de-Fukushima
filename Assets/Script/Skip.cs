using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum load
{
    jogar,ending
}
public class Skip : MonoBehaviour
{
    public load load;
    public string SceneName;
    public string SceneName2;
    public string SceneName3;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mudar();
        }
        
    }

    void mudar()
    {
        switch (load)
        {
            case load.jogar:
                SceneManager.LoadScene(SceneName);
                SceneManager.LoadSceneAsync(SceneName2, LoadSceneMode.Additive);
                SceneManager.LoadSceneAsync(SceneName3, LoadSceneMode.Additive);
                break;
            case load.ending:
                SceneManager.LoadScene(SceneName);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            default:
                break;
        }
    }
}
