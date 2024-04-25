using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameManager manager;

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

        vectorMovement = new Vector3(horizontalInput, 0, verticalInput);
        vectorMovement.Normalize();

        if (puedeMoverse == true)
            transform.Translate(vectorMovement * Time.deltaTime * speed);


        if (saltando && Input.GetButtonDown("Jump") || cantidadDeSaltos > 0 && Input.GetButtonDown("Jump") )
            Saltar();
    }



    private void Saltar()
    {
        _rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);

        saltando = false;
        cantidadDeSaltos -= 1;


        //en el script de power up agregar un salto ( cantidad de salto += 1;)
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



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        manager.Coleccionables();
        //Activar particulas
    }

}

