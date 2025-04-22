using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoviemientoX : MonoBehaviour
{
    public float velocidad = 5f;
    public float Sprint = 3f;
    public Animator animator;
    public float fuerzaSalto = 8f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    
    private BoxCollider2D boxCollider;

    private bool enSuelo;
    private Rigidbody2D rb;

    private bool enSprint;
        // Start is called before the first frame update
    private AudioSource audioSource;
    private bool boolParaCaminar = false;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();
    audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
    float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;
    float sprintX = Input.GetAxis("Horizontal")*Time.deltaTime*Sprint;
    float escalarY = Input.GetAxis("Vertical")*Time.deltaTime*velocidad;

    animator.SetFloat("Movement", velocidadX*velocidad);
    
    

    if(velocidadX < 0)
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }
    else if(velocidadX > 0)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    Vector3 posicion = transform.position;

    if(Input.GetKey(KeyCode.LeftShift) && velocidadX !=0)
    {   
        //GameManager.Instance.PlayCorrerSound();
        animator.SetBool("enSprint", enSprint);
        transform.position = new Vector3(velocidadX + sprintX + posicion.x, posicion.y, posicion.z);  
    }
    else
    {  

    if ((velocidadX != 0) && enSuelo && !audioSource.isPlaying && !boolParaCaminar) 
    {
        boolParaCaminar = true;
        GameManager.Instance.PlayCaminarSound();
    }
    else if (velocidadX == 0 || !enSuelo)
    {
        if (audioSource.isPlaying) 
        {
            audioSource.Stop();
            boolParaCaminar = false;
        }
    }
        

        animator.SetBool("enSprint", !enSprint);
        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
    }

    if (enSuelo && Input.GetKeyDown(KeyCode.Space))
    {
        GameManager.Instance.PlaySaltoSound();
        rb.AddForce(new Vector2(0f,fuerzaSalto), ForceMode2D.Impulse);
    }

    animator.SetBool("enSuelo", enSuelo);

    if(boxCollider.IsTouchingLayers(LayerMask.GetMask("Escalera")) && Input.GetKey(KeyCode.W)){

        transform.position = new Vector3(posicion.x, posicion.y + escalarY, posicion.z);
        rb.gravityScale = 0f;
    }
    else{
        rb.gravityScale = 1f;
    }
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
    enSuelo = hit.collider != null;

    }

    void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
}




}

