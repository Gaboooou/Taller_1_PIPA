using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 0.1f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - 0.1f);
            }
        }
    }

}
