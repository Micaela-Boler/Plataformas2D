using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    [SerializeField] float distancia;
    [SerializeField] float rapidezDeMovimiento;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 2, -distancia), rapidezDeMovimiento * Time.deltaTime);
    }
}
