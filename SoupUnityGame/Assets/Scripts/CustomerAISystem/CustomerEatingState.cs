using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEatingState : CustomerAIState
{
    private float eatingTimer = 0f;
    private float totalEatingTime = 2f;

    public override void InitializeState()
    {
        customerAI.SaveNavMeshPos();
        customerAI.SetNavMeshAgentActive(false);
        customerAI.transform.position = customerAI.GetChair().transform.position;
    }

    public override void RealUpdate()
    {
        if (totalEatingTime > eatingTimer)
        {
            eatingTimer += Time.deltaTime;
        }
        else
        {
            eatingTimer = 0f;
            
            customerAI.MoveToSavedNavMeshPos();
            customerAI.SetNavMeshAgentActive(true);

            customerAI.SetNextWalkingDestination(CustomerWalkingState.NextAction.Leaving,
                CustomerAIManager.Instance().GetCustomerSpawnPoint());
            customerAI.SwitchToWalking();
        }
    }
}
