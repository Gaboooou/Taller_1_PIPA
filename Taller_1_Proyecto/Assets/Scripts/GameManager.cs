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

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
