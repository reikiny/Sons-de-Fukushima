using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class LegendaManager : MonoBehaviour
{
    public Text text;
    public AudioSource audioSource;
    BoxCollider m_Collider;
    public Legenda[] legenda;
    public float[] tempoDoAudio;
    public GameObject evento;
    public bool ComEvento;

    
    private bool tocou;
    private int contador;

    
    private void Start()
    {
        contador = legenda.Length - 1;
        audioSource = GetComponent<AudioSource>();
        m_Collider = GetComponent<BoxCollider>();
        text = GameObject.Find("Subtatle").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(enumerator());
            m_Collider.enabled = !m_Collider.enabled;
        }
    }

    public IEnumerator enumerator()
    {
        for (int i = 0; i < tempoDoAudio.Length; i++)
        {
            
            tempoDoAudio[i] = legenda[i].audio.length;
            audioSource.PlayOneShot(legenda[i].audio);
            text.text = (legenda[i].subtitle);
            yield return new WaitForSeconds(tempoDoAudio[i]);
            if (contador == i && ComEvento)
            {
                evento.SetActive(true);
                text.text = "";
                StopCoroutine(enumerator());

            }
            else
            {
                text.text = "";
                StopCoroutine(enumerator());
            }
            

        }
        
        
    }
}
