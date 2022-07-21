using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (findDistance(player.transform, transform) > 50 )
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    float findDistance(Transform pointA, Transform pointB)
    {
        return Mathf.Sqrt(Mathf.Pow((pointA.transform.position.x - pointB.transform.position.x), 2)
          + Mathf.Pow((pointA.transform.position.z - pointB.transform.position.z), 2));
    }
}