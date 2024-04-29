using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] float tiempoMaximo = 500f;
    [SerializeField] float tiempoActual;
    [SerializeField] bool activadoTiempo;
    [SerializeField] Slider slider;

    public GameManager manager;



    private void Start()
    {
        Activar();
    }


    void Update()
    {
        if (activadoTiempo)
            CambiarTimer();
    }



    void CambiarTimer()
    {
        tiempoActual -= Time.deltaTime * 10;


        if (tiempoActual >= 0)
            slider.value = tiempoActual;

        if (tiempoActual <= 0)
        {
            manager.CambiarEscena(0);
            EstadoDeTimer(false);
        }
    }



    void Activar()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;

        EstadoDeTimer(true);
    }


    public void EstadoDeTimer(bool estado)
    {
        activadoTiempo = estado;
    }

}
