using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Sonar : MonoBehaviour
{

    public GameObject detectingObject;
    public GameObject playerObject;



    public ParticleSystem sonar;
    public GameObject particula;
    public float velocity;

    public bool entrou;
    float distance;
    float Milisieverts;

    private void Start()
    {
        sonar = GameObject.Find("Sonar").GetComponent<ParticleSystem>();
        particula = GameObject.FindGameObjectWithTag("soul");
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        conta();
    }

    //ARRUMAR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    void conta()
    {
        if (entrou)
        {
            particula.SetActive(true);
            distance = (detectingObject.transform.position - playerObject.transform.position).magnitude;
            Milisieverts = 5 / distance;

            float Distance = 10f;
            float soulDistance = Distance * Milisieverts;
            velocity = (soulDistance / Distance);
            
            ChangeSpeed(sonar, velocity);

        }
    }

    private void ChangeSpeed(ParticleSystem particle, float speed)
    {
        var main = particle.main;
        main.simulationSpeed = speed;

    }
    //quando entra na zona do objeto
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entrou = !entrou;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            particula.SetActive(false);
            entrou = !entrou;
        }
    }


}
