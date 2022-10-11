using System;
using UnityEngine;

public class FieldOfViewEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask targetMask, obstructionMask;
    public float radius;
    public float angle;
    public bool canSeePlayer;

    public Transform player;
    private void Update()
    {
        FieldOfViewCheck();
    }

    void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            player = target;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            CheckAngle(transform.forward, directionToTarget);
        }
        else
        {
            canSeePlayer = false;
        }
    }

    void CheckAngle(Vector3 from, Vector3 to)
    {
        if (Vector3.Angle(from, to) < angle / 2f)
        {
            if (Physics.Raycast(transform.position, to, Mathf.Infinity, obstructionMask))
            {
                canSeePlayer = false;
            }
            else
            {
                canSeePlayer = true;
            }
        }
        else
        {
            Debug.Log("Player is not in the vision");
            canSeePlayer = false;
        }
    }
}