using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List <GameObject> corazones = new List <GameObject> ();
    [SerializeField] Sprite corazonDesactivado;

    [SerializeField] TextMeshProUGUI textoPuntaje;   

    int puntos;




    public void Coleccionables()
    {
        puntos++;
        textoPuntaje.text = puntos.ToString();
        //actualizar interfaz
    }


    public void CambiarCorazon(int indice)
    {
        Image imagenCorazon = corazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }

    //metado para activar corazon??

}
