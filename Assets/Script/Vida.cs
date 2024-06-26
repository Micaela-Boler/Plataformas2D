using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private int vida = 3;

    public GameManager gameManager;

    [Header("Rebote")]

    [SerializeField] float tiempo;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audio;
    public Jugador jugador;



    public void RecibirDaņo(int daņo, Vector2 posicion)
    {
        if (vida > 0)
        {
            vida -= daņo;
            audio.Play();
            gameManager.CambiarCorazon(vida);


            if (vida <= 0)
                gameManager.CambiarEscena(0);
        }

        StartCoroutine(PerderControl());
        jugador.Rebote(posicion);   
    }



    IEnumerator PerderControl()
    {
        jugador.puedeMoverse = false;
        animator.SetBool("RecibiendoDaņo", true);

        yield return new WaitForSeconds(tiempo);

        jugador.puedeMoverse = true;
        animator.SetBool("RecibiendoDaņo", false);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
            gameManager.CambiarEscena(0);
    }
}
