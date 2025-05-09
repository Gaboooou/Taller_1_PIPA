using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            FindAnyObjectByType<GameOver>().mostrarGameOver();
            FindAnyObjectByType<ocultar>().ocultarPANEL();
        }
    }

}
