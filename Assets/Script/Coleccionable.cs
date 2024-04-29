using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [SerializeField] ParticleSystem particulas;
    [SerializeField] AudioSource audio;

    public GameManager manager;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            manager.Coleccionables();
            particulas.Play();
            audio.Play();

            Destroy(gameObject, 0.5f);
        }
    }
}
