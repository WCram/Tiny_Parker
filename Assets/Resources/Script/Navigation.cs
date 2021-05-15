using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    [SerializeField]private Transform[] wayPoints;
    [SerializeField] private int current = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[current].position) >= 4)
        {
            agent.SetDestination(wayPoints[current].position);
        }
        else
        {
            current = (current == wayPoints.Length - 1) ? 0 : current + 1;
        }
    }
}
