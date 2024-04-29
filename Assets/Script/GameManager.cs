using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    
    [SerializeField] List <GameObject> corazones = new List <GameObject> ();
    [SerializeField] Sprite corazonDesactivado;

    [SerializeField] TextMeshProUGUI textoPuntaje;

    [SerializeField] GameObject pantalla;
    int cantidadDeColeccionables;
    int puntos;



    private void Start()
    {
        cantidadDeColeccionables = GameObject.FindGameObjectsWithTag("Coleccionables").Length;
        pantalla.SetActive(false);
    }



    public void Coleccionables()
    {
        puntos++;

        textoPuntaje.text = puntos.ToString() + "/" + cantidadDeColeccionables.ToString();

        if (puntos == cantidadDeColeccionables)
        {
            pantalla.SetActive(true);
            timer.EstadoDeTimer(false);
        }
    }



    public void CambiarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }


    public void CambiarCorazon(int indice)
    {
        Image imagenCorazon = corazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }
}
