using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            if (gameObject.CompareTag("Mon_Amarillo"))
            {
                print("Moneda Amarilla");
                GameManager.Instance.SumarPuntos(1);
            }
            else if (gameObject.CompareTag("Mon_Lila"))
            {
                GameManager.Instance.SumarPuntos(2);
            }
            else if (gameObject.CompareTag("Mon_Azul"))
            {
                GameManager.Instance.SumarPuntos(5);
            }
            else if (gameObject.CompareTag("Mon_Verde")) 
            {
                GameManager.Instance.SumarPuntos(10); // Default value if no tag matches
            }
            
            Destroy(gameObject);

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
