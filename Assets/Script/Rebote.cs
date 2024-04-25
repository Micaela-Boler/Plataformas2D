using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    public Vida vida;
    [SerializeField] int da�o;

    private void OnCollisionEnter(Collision collision)
    {
        // get contact = se refiere a la posicion donde ocurre la colision
        if (collision.gameObject.CompareTag("Jugador"))
            vida.RecibirDa�o(da�o, collision.GetContact(0).normal);

    }
}
