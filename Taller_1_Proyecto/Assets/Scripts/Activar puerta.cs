using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarpuerta : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            FindAnyObjectByType<Victoria>().mostrarVictoria();
            FindAnyObjectByType<ocultar>().ocultarPANEL();
        }
    }
}