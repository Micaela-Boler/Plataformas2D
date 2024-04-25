using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    //[SerializeField] ParticleSystem particulas;

    private int vida = 3;

    public GameManager gameManager;

    [Header("Rebote")]
    public Jugador jugador;
    [SerializeField] float tiempo;



    void Start()
    {
        //particulas.Stop();
    }



    public void RecibirDaño(int daño, Vector2 posicion)
    {
        if (vida > 0)
        {
            vida -= daño;
            //particulas.Play();
            // trigger para la animacion
            gameManager.CambiarCorazon(vida);

            if (vida <= 0)
                Debug.Log("Sin vidas");
        }

        StartCoroutine(PerderControl());
        jugador.Rebote(posicion);   
    }



    IEnumerator PerderControl()
    {
        jugador.puedeMoverse = false;

        yield return new WaitForSeconds(tiempo);

        jugador.puedeMoverse = true;

    }
}
