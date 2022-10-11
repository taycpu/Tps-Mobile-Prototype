using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIEnemy : Unit
{
    public Guid id = new Guid();

    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected AgentPointController pointController;

    public override void Initialize()
    {
        base.Initialize();
        transform.position = pointController.GetNewTarget(id).point.position;
        gameObject.SetActive(true);
        SetNewDestination();
        agent.speed = unitAttributes.Speed;
    }

    protected void Patrol()
    {
        if (agent.isStopped)
            agent.isStopped = false;
        if (agent.remainingDistance < 0.1f)
            SetNewDestination();
    }

    private void SetNewDestination()
    {
        var obj = pointController.GetNewTarget(id);
        agent.SetDestination(obj.point.position);
    }

    protected override void Die()
    {
        agent.isStopped = true;
    }
}