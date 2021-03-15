using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDoObjeto : MonoBehaviour
{
    public static TextoDoObjeto current;
    public Text interagir;

    private void Start()
    {
        action += WithText;
        noAction += WithoutText;
    }

    private void Awake()
    {
        current = this;
    }

    public Action action;
    void WithText()
    {
        interagir.text = "E";
    }
    public Action noAction;
    void WithoutText()
    {
        interagir.text = "";
    }


}
