using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MARAVILHOSO : MonoBehaviour
{
    public bool desativa;
    public UnityEvent evento;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (desativa)
            {
                gameObject.SetActive(false);
            }
            evento?.Invoke();
        }
    }
}
