using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text textPuntos;

    public GameObject gameOverPanel;

    public void mostrarGameOver(){
        gameOverPanel.SetActive(true);
        textPuntos.text = "Puntos: " + FindAnyObjectByType<GameManager>().puntos.ToString();
        FindAnyObjectByType<GameManager>().puntos = 0;
    }

    public void ReiniciarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindAnyObjectByType<ocultar>().mostrarPANEL();
    }

}
