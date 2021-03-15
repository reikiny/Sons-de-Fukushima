using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaAlma : MonoBehaviour
{
    public GameObject alma;
    public GameObject desligarObjeto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alma.SetActive(true);
            desligarObjeto.SetActive(false);
        }
    }
}
