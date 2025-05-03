using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text textPuntos;

    public GameObject gameOverPanel;

    public void mostrarGameOver(){
        gameOverPanel.SetActive(true);
        textPuntos.text = "Puntos: " + FindAnyObjectByType<GameManager>().puntos.ToString();
    }
}
