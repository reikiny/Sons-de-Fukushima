using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public enum QualTremor
{
    InverterControle,
    TremorLeve,
    TremorRapido
}
public class Trauma : MonoBehaviour
{
    float distance;
    float Milisieverts;
    GameObject playerObject;
    bool desativar;
    private Controller controller;
    float magnitude;
    [Tooltip("InverterControle para inverter" + "\n" + "TremorRapido tremor para dar um sustinho" + "\n" + "TremorLeve tremor leve ")]
    public QualTremor qualTremor;
    [Header("Inverter Controles")]
    public bool InverterControle;
    [Header("So usar quando for tremor leve ou rapido")]
    public float NivelTremor;
    

    private void Start()
    {
        controller = FindObjectOfType<Controller>();
        playerObject = GameObject.Find("FPSCharacter");
    }
    private void Update()
    {
        Tremores();
        if (InverterControle)
        {
            Controller.Inverter = true;
            controller.PlayerSpeed = controller.PlayerSpeed / 2;
            InverterControle = false;
        }
    }

    void Tremores()
    {
        switch (qualTremor)
        {
            case QualTremor.InverterControle:
                Tremor();
                break;
            case QualTremor.TremorLeve:
                TremorLeve();
                break;
            case QualTremor.TremorRapido:
                StartCoroutine(acabar());
                break;
            default:
                break;
        }
    }
    void Tremor()
    {
        distance = (transform.position - playerObject.transform.position).magnitude;
        magnitude = 0.5f / distance;
        NivelTremor = Mathf.Clamp(magnitude, 0.01f, 0.05f);
        CameraShake.current.CameraTremor(NivelTremor);
    }
    void TremorLeve()
    {
        CameraShake.current.CameraTremor(NivelTremor);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    public IEnumerator acabar()
    {
        StartCoroutine(CameraShake.current.Shake(1f, NivelTremor));
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

}
