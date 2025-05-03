using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class MoviemientoX : MonoBehaviour
{
    public float velocidad = 5f;
    public float Sprint = 3f;
    public Animator animator;
    public float fuerzaSalto = 8f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    public SoundManager soundManager;
    
    private BoxCollider2D boxCollider;

    private bool enSuelo;
    private Rigidbody2D rb;

    private bool enSprint;

    // Start is called before the first frame update

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();
    soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
    float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;
    float sprintX = Input.GetAxis("Horizontal")*Time.deltaTime*Sprint;
    float escalarY = Input.GetAxis("Vertical")*Time.deltaTime*velocidad;

    animator.SetFloat("Movement", velocidadX*velocidad);

    if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
    //soundManager.PlaySound(0,0.5f);
    if(velocidadX < 0)
    {
        transform.localScale = new Vector3(-1, 1, 1);
        
    }
    else if(velocidadX > 0)
    {   
        transform.localScale = new Vector3(1, 1, 1);
        
    }
    

    }

    Vector3 posicion = transform.position;

    if(Input.GetKey(KeyCode.LeftShift) && velocidadX !=0)
    {   
        animator.SetBool("enSprint", enSprint);
        transform.position = new Vector3(velocidadX + sprintX + posicion.x, posicion.y, posicion.z);  
    }
    else
    {   

        animator.SetBool("enSprint", !enSprint);
        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
    }

    
    if (enSuelo && Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(new Vector2(0f,fuerzaSalto), ForceMode2D.Impulse);
        soundManager.PlaySound(2,0.8f);
    }

    if (enSuelo && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow)))
    {
        soundManager.PlaySound(1,0.5f);
    }

    animator.SetBool("enSuelo", enSuelo);

    if(boxCollider.IsTouchingLayers(LayerMask.GetMask("Escalera")) && (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))){

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

