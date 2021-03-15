
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

[RequireComponent(typeof(EnumGlobal),typeof(AudioSource))]
public class ObjetoController : MonoBehaviour
{
    public int id;
    [SerializeField] private Material _highlightMaterial;
    [SerializeField] private Material _defaultMaterial;
    public AudioClip liberar;
    public AudioSource source;
    AudioSource sourceFala;
    public GameObject soul;
    public GameObject[] ligarObjects;
    public GameObject[] desligarObjects;

    //legenda
    Text subtitle;
    public Legenda[] legenda;
    float[] tempoDoAudio;
    private int contador;
    bool pegou;

    //rotaçao 
    private Transform ondeVai;
    public PostProcessVolume volume;
    private DepthOfField _DepthOfField;
    EnumGlobal enumGlobal;
    Vector3 posiconOriginal;
    Quaternion rotationOriginal;
    bool rotacion;
    float rotSpeed = 20f;

    [Header("UI")]
    Text nomeTxt;
    Text descricaoText;

    public string nome;
    [TextArea]
    public string description;


    private void Start()
    {
        volume.profile.TryGetSettings(out _DepthOfField);
        enumGlobal = GetComponent<EnumGlobal>();

        ObjectEvent.current._withHighLight += highlight;
        ObjectEvent.current._withoutHighLight += defaultMaterial;
        ObjectEvent.current._fazerAlgo += tirar;
        ObjectEvent.current._rotacionar += rotacionar;
        ObjectEvent.current._ob += ti;

        subtitle = GameObject.Find("Canvas/Subtatle").GetComponent<Text>();
        nomeTxt = GameObject.Find("Canvas/ObjDescrição/Nome").GetComponent<Text>();
        descricaoText = GameObject.Find("Canvas/ObjDescrição/Descrição").GetComponent<Text>();

        ondeVai = GameObject.Find("Olhos").GetComponent<Transform>();
        soul = GameObject.Find("Sonar");
        posiconOriginal = transform.position;
        rotationOriginal = transform.rotation;

        tempoDoAudio = new float[legenda.Length];
        sourceFala = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void highlight(int id)
    {
        if (id == this.id)
        {
            gameObject.GetComponent<MeshRenderer>().material = _highlightMaterial;
        }
    }

    void defaultMaterial(int id)
    {
        if (id == this.id)
        {
            gameObject.GetComponent<MeshRenderer>().material = _defaultMaterial;
        }
    }

    void tirar(int id)
    {
        if (id == this.id)
        {
            StartCoroutine(enumerator());
            gameObject.layer = LayerMask.NameToLayer("Focused");
            enumGlobal._interativo = interativo.objectosRotacao;
            transform.position = ondeVai.position;
            Controller.podeMover = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            rotacion = true;
            _DepthOfField.active = true;

            if (!pegou)
            {
                source.PlayOneShot(liberar);
                pegou = true;
            }

            nomeTxt.text = nome;
            descricaoText.text = description;
            nomeTxt.transform.parent.gameObject.SetActive(true);

        }
    }
    void ti(int id)
    {
        if (id == this.id)
        {
            StartCoroutine(enumerator());
            for (int i = 0; i < desligarObjects.Length; i++)
            {
                desligarObjects[i].SetActive(false);

            }
            
            
            soul.SetActive(false);
        }
    }

    void rotacionar(int id)
    {
        if (id == this.id)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            enumGlobal._interativo = interativo.objetos;
            rotacion = false;
            transform.position = posiconOriginal;
            transform.rotation = rotationOriginal;
            Controller.podeMover = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _DepthOfField.active = false;

            for (int i = 0; i < ligarObjects.Length; i++)
            {
                ligarObjects[i].SetActive(true);
            }
            for (int i = 0; i < desligarObjects.Length; i++)
            {
                desligarObjects[i].SetActive(false);
            }

            nomeTxt.transform.parent.gameObject.SetActive(false);
            soul.SetActive(false);
        }
    }

    private void OnMouseDrag()
    {
        if (rotacion)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotX);
            transform.RotateAround(Vector3.right, rotY);
        }
    }
    public IEnumerator enumerator()
    {
        for (int i = 0; i < tempoDoAudio.Length; i++)
        {

            tempoDoAudio[i] = legenda[i].audio.length;
            sourceFala.PlayOneShot(legenda[i].audio);
            subtitle.text = (legenda[i].subtitle);
            yield return new WaitForSeconds(tempoDoAudio[i]);
            subtitle.text = "";
            StopCoroutine(enumerator());

        }

    }
}
