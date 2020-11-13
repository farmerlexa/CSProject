using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] Collider player;
    public bool canSeePlayer = false;
    public RaycastHit hit;
    [SerializeField] LayerMask mask;

    void OnTriggerStay(Collider other)
    {
        if (other == player)
        {
            if (Physics.Linecast(GetComponentInParent<Transform>().position, player.transform.position, out hit, mask))
            {
                canSeePlayer = hit.transform.Equals(player.transform);
                Debug.Log(hit.transform);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == player)
            canSeePlayer = false;
    }
}
