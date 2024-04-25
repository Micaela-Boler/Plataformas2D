using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DobleSalto : PowerUp
{
    public override void aplicar(GameObject jugador)
    {
        jugador.GetComponent<Jugador>().cantidadDeSaltos += 1;
    }
}
