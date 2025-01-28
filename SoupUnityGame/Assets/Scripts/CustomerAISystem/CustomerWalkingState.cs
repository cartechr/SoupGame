using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerWalkingState : CustomerAIState
{
    private NavMeshAgent agent;
    public override void RealUpdate()
    {
       
    }
    public void AssignWalkingVariables(NavMeshAgent navmeshagent)
    {
        agent = navmeshagent;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetDestination(Transform dest)
    {
        agent.SetDestination(dest.position);
    }
}
