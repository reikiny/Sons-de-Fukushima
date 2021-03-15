using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumGlobal : MonoBehaviour
{
   
    public static EnumGlobal current;
    public int _id;
    public interativo _interativo;
   

    private void Awake()
    {
        current = this;

    }



}
