using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarPowerUp : MonoBehaviour
{
    public PowerUp powerUp;

    [SerializeField] AudioSource audio;
    [SerializeField] ParticleSystem particulas;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            powerUp.aplicar(other.gameObject);
            particulas.Play();
            audio.Play();

            Destroy(gameObject, 0.5f);
        }
    }
}
