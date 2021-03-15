using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadEvets : MonoBehaviour
{
    public static loadEvets current;
    public int id;
    public string scene;


    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        load += ultimo;
    }

    public Action load;
    void ultimo()
    {
        SceneManager.LoadScene(scene);
    }

   public void chamar()
    {
        load?.Invoke();
    }

}
