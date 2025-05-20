using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IANavigation : MonoBehaviour
{
    public Transform objetivo; // Referencia al objeto al que la IA debe moverse
    public float velocidad = 3.5f; // Velocidad de movimiento del agente
    private NavMeshAgent navMeshAgent;
    private Vector3 ultimaPosicionObjetivo;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("El componente NavMeshAgent no está adjunto a este objeto.");
        }
        else if (objetivo == null)
        {
            Debug.LogError("El objetivo no está asignado. Asigne el objeto al que la IA debe moverse.");
        }
        else
        {
            navMeshAgent.speed = velocidad; // Establecer la velocidad inicial
            ultimaPosicionObjetivo = objetivo.position;
            MoverHaciaObjetivo();
        }
    }

    void MoverHaciaObjetivo()
    {
        if (navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(ultimaPosicionObjetivo);
        }
    }

    void Update()
    {
        // Verificar si el objetivo se ha movido
        if (objetivo.position != ultimaPosicionObjetivo)
        {
            ultimaPosicionObjetivo = objetivo.position;
            MoverHaciaObjetivo();
        }

        // Actualizar la velocidad del NavMeshAgent
        if (navMeshAgent.speed != velocidad)
        {
            navMeshAgent.speed = velocidad;
        }
    }
}