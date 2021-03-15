using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEvent : MonoBehaviour
{
    public static ObjectEvent current;

    private void Awake()
    {
        current = this;
    }

    public  event Action<int> _withHighLight;

    public void withHighLight(int id)
    {

        _withHighLight?.Invoke(id);

    }
    public event Action<int> _withoutHighLight;
    public void withoutHighLight(int id)
    {

        _withoutHighLight?.Invoke(id);

    }

    public event Action<int> _fazerAlgo;
    public void fazerAlgo(int id)
    {
        _fazerAlgo?.Invoke(id);
    }
    public event Action<int> _rotacionar;
    public void rotacionar(int id)
    {
        _rotacionar?.Invoke(id);
    }
    public event Action<int> _ob;
    public void NaoRotacionar(int id)
    {
        _ob?.Invoke(id);
    }
}
