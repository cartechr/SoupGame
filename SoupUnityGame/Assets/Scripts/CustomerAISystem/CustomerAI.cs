using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAI : MonoBehaviour
{

    private CustomerWalkingState walkingState;
    private CustomerEatingState eatingState;
    private CustomerOrderingState orderingState;
    private CustomerAIState currentstate;

    // Start is called before the first frame update
    void Start()
    {
        walkingState = new CustomerWalkingState();
        walkingState.AssignCustomerAI(this);
        eatingState = new CustomerEatingState();
        eatingState.AssignCustomerAI(this);
        orderingState = new CustomerOrderingState();
        orderingState.AssignCustomerAI(this);

        currentstate = walkingState;
    }

    // Update is called once per frame
    void Update()
    {
        currentstate.RealUpdate();
    }
    
    public void SwitchToWalking()
    {
        currentstate = walkingState;
    }

    public void SwitchToEating()
    {
        currentstate = eatingState;
    }

    public void SwitchToOrdering()
    {
        currentstate = orderingState;
    }
}
