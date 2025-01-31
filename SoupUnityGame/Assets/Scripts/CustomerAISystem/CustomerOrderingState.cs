using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderingState : CustomerAIState
{
    public override void InitializeState()
    {
        PipeController[] pipes = customerAI.GetTable().GetPipes();
        PipeController chosenPipe = pipes[Random.Range(0, pipes.Length)];
        chosenPipe.TakeSoup();
        customerAI.SwitchToEating();
    }

    public override void RealUpdate()
    {

    }
}
