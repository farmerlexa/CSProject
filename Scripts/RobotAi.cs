using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RobotAi : MonoBehaviour
{
    NavMeshAgent robot;
    Vision vision;
    [SerializeField] Transform gun;
    [SerializeField] Transform player;


    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<NavMeshAgent>();
        vision = GetComponentInChildren<Vision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vision.canSeePlayer)
        {
            gun.LookAt(player);
            robot.SetDestination(player.position);
        }
    }

    void GotoRandom()
    {
    }

    Vector3 GetRandDest()
    {
        return new Vector3();
    }
}
