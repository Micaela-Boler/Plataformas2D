using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem particulas;
    
    [Header("Movimiento")]

    private float horizontalInput;
    private float verticalInput;    
    private Vector3 vectorMovement;
    public float speed;


    [Header("Salto")]

    [SerializeField] Rigidbody _rb;
    public float fuerzaDeSalto;
    bool saltando;
    public int cantidadDeSaltos;


    [Header("Rebote")]

    [SerializeField] Vector2 velocidadDeRebote;
    public bool puedeMoverse;



    private void Start()
    {
        puedeMoverse = true;
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        vectorMovement = new Vector3(-verticalInput, 0, horizontalInput);
        vectorMovement.Normalize();


        if (puedeMoverse == true)
        {
            transform.Translate(vectorMovement * Time.deltaTime * speed);

            animator.SetFloat("Corriendo", Mathf.Abs(horizontalInput));
        }



        if (saltando && Input.GetButtonDown("Jump") || cantidadDeSaltos > 0 && Input.GetButtonDown("Jump"))
            Saltar();
        else
            animator.SetBool("Saltando", false);
    }



    private void Saltar()
    {
        _rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);


        saltando = false;
        cantidadDeSaltos -= 1;
        animator.SetBool("Saltando", true);
    }

    public void Rebote(Vector2 puntoDeGolpe)
    {
        _rb.velocity = new Vector2(-velocidadDeRebote.x * puntoDeGolpe.x, velocidadDeRebote.y);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            saltando = true;
            cantidadDeSaltos += 1;
        } 
    }
}

