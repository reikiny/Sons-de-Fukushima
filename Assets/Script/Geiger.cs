using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Geiger : MonoBehaviour
{
    public Text contador;
    public Animator myAnimation;
    bool ativarBotao;

    public Action<bool> geigerAni;
    public Action<float> geigermSv;

    private void Start()
    {
        geigerAni += animator;
        geigermSv += contadorGeiger;
    }
    private void Update()
    {

        Botao();
    }

    //fazer clicar no botao
    void Botao()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !ativarBotao)
        {
            ativarBotao = !ativarBotao;
            myAnimation.SetBool("Ativar", true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && ativarBotao)
        {
            ativarBotao = !ativarBotao;
            myAnimation.SetBool("Ativar", false);
        }

    }

    //quando aparecer perto da zona de radiaçao
    //usando Action no Script Radiation
    private void animator(bool entro)
    {
        if (entro)
        {
            myAnimation.SetBool("Ativar", true);
        }
        else if (!entro)
        {
            myAnimation.SetBool("Ativar", false);
        }
    }

    //quando mais proximo do objeto radioativo aumenta o mSv 
    //usando Action no Script Radiation
    void contadorGeiger(float mSv)
    {
        contador.text = mSv.ToString("0.00") + "mSv";
    }

}
