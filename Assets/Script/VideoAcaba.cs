using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoAcaba : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public string SceneName;
    public string SceneName2;
    public string SceneName3;
    public bool ending;
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        
        
            SceneManager.LoadScene(SceneName);
            SceneManager.LoadScene(SceneName2, LoadSceneMode.Additive);
            SceneManager.LoadScene(SceneName3, LoadSceneMode.Additive);
            if(ending)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
