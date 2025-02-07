using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerWalkingState : CustomerAIState
{
    public enum NextAction
    {
        Queue, Eating, Ordering, Leaving
    }

    private NextAction nextAction;
    private NavMeshAgent agent;

    public override void InitializeState()
    {
        
    }

    public override void RealUpdate()
    {
        if (agent.remainingDistance == 0)
        {
            switch (nextAction)
            {
                case NextAction.Queue:
                    //customerAI.SwitchToQueue();
                    break;
                case NextAction.Eating:
                    customerAI.SwitchToEating();
                    break;
                case NextAction.Ordering:
                    customerAI.SwitchToOrdering();
                    break;
                case NextAction.Leaving:
                    customerAI.GetTable().SetOccupied(false);
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
