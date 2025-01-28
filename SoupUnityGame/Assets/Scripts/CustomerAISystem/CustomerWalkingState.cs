using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerWalkingState : CustomerAIState
{
    private NavMeshAgent agent;

    public enum NextAction
    {
        Eating, Ordering, Leaving
    }

    NextAction nextAction;
    public override void RealUpdate()
    {
        if (agent.remainingDistance == 0)
        {
            switch (nextAction)
            {
                case NextAction.Eating:
                    customerAI.SwitchToEating();
                    break;
                case NextAction.Ordering:
                    customerAI.SwitchToOrdering();
                    break;
                case NextAction.Leaving:
                    customerAI.UnAlive();
                    break;
            }
        }
    }
    public void AssignWalkingVariables(NavMeshAgent navmeshagent)
    {
        agent = navmeshagent;

        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    public void SetDestination(NextAction newAction, Transform dest)
    {
        nextAction = newAction;
        agent.SetDestination(dest.position);
    }
}
