using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float velocidad;

    [SerializeField] LayerMask capaAbajo;
    [SerializeField] LayerMask capaFrente;

    [SerializeField] float distanciaAbajo;
    [SerializeField] float distanciaFrente;

    [SerializeField] Transform controladorAbajo;
    [SerializeField] Transform controladorFrente;

    [SerializeField] bool informacionAbajo;
    [SerializeField] bool informacionFrente;

    bool mirandoDerecha;
    bool mirandoIzquierda;




    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    

    void Update()
    {
        rb.velocity = new Vector3 (-velocidad, rb.velocity.y , 0);

        // vector de origen ( donde empieza el raycast) - transform= la direccionn (ene este caso la derecha) - float, la distancia que debe de recorrer - LayerMask, la capa que tiene que detectar
        //Usamos raycast para detectar la colision con las paredes o limites
        informacionFrente = Physics.Raycast(controladorFrente.position, transform.right, distanciaFrente, capaFrente);
        informacionAbajo = Physics.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

       
        if (!informacionAbajo || informacionFrente)
            Girar();

    }



    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorFrente.transform.position, controladorFrente.transform.position + transform.right * distanciaFrente);
    }
}
