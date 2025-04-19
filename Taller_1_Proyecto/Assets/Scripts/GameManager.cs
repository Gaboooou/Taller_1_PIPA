using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    public int puntos = 0;
    public TMP_Text puntostext;
    public AudioSource audioSource;
    public AudioClip SonidoGema;
    public AudioClip Correr;
    public AudioClip Saltar;
    public AudioClip Caminar;
    
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void SumarPuntos(int SumarPuntos)
    {
        puntos += SumarPuntos;
        PlayPointSound();
        ActualizarPuntosUI();
    }

    public void PlayPointSound()
    {
        audioSource.PlayOneShot(SonidoGema);
    }

    void ActualizarPuntosUI()
    {
        if(puntostext != null)
        {
            puntostext.text = puntos.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayCorrerSound()
    {
        audioSource.PlayOneShot(Correr);
    }

public void PlayCaminarSound()
    {
        audioSource.PlayOneShot(Caminar);
    }

public void PlaySaltoSound()
    {
        audioSource.PlayOneShot(Saltar);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
