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
        int rr = Random.Range(0, agentPoints.Count);
        var obj = agentPoints[rr];

        if (obj.registeredBots.Contains(id))
        {
            obj.registeredBots.Remove(id);
            int xx = Random.Range(0, agentPoints.Count);
            while (xx == rr)
            {
                xx = Random.Range(0, agentPoints.Count);
            }

            obj = agentPoints[xx];
        }


        return obj.Register(id);
    }
}