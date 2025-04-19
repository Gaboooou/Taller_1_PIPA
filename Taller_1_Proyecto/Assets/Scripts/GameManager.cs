using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    public int puntos = 0;
    public TMP_Text puntostext; 
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
        ActualizarPuntosUI();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
