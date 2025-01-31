using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerAIState
{
    protected CustomerAI customerAI;

    public abstract void InitializeState();
    public abstract void RealUpdate();
    public void AssignCustomerAI(CustomerAI newCustomerAI)
    {
        customerAI = newCustomerAI;
    }
}
