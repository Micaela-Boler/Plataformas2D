using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    public Vida vida;
    [SerializeField] int daño;

    private void OnCollisionEnter(Collision collision)
    {
        // get contact = se refiere a la posicion donde ocurre la colision
        if (collision.gameObject.CompareTag("Jugador"))
            vida.RecibirDaño(daño, collision.GetContact(0).normal);

    }
}
