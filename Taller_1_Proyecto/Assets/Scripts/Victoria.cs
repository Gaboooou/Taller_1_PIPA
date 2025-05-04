using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victoria : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text textPuntos;

    public GameObject gameOverPanel;

    public void mostrarVictoria(){
        gameOverPanel.SetActive(true);
        textPuntos.text = "Puntos: " + FindAnyObjectByType<GameManager>().puntos.ToString();
    }
}
