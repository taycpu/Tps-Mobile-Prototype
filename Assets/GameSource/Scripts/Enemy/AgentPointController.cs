using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public class AgentPoint
{
    public Transform point;
    public HashSet<Guid> registeredBots = new HashSet<Guid>();

    public AgentPoint Register(Guid i)
    {
        registeredBots.Add(i);
        return this;
    }
}

public class AgentPointController : MonoBehaviour
{
    public List<AgentPoint> agentPoints;


    public AgentPoint GetNewTarget(Guid id)
    {
        int oldPoint = Random.Range(0, agentPoints.Count);
        var obj = agentPoints[oldPoint];

        if (obj.registeredBots.Contains(id))
        {
            obj.registeredBots.Remove(id);
            int randPoint = Random.Range(0, agentPoints.Count);
            while (randPoint == oldPoint)
            {
                randPoint = Random.Range(0, agentPoints.Count);
            }

            obj = agentPoints[randPoint];
        }


        return obj.Register(id);
    }
}