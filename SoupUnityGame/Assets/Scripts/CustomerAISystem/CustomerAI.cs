using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private CustomerWalkingState walkingState;
    private CustomerEatingState eatingState;
    private CustomerOrderingState orderingState;
    private CustomerAIState currentstate;

    private Table table;

    // Start is called before the first frame update
    void Start()
    {
        // initializing states
        walkingState = new CustomerWalkingState();
        walkingState.AssignCustomerAI(this);
        eatingState = new CustomerEatingState();
        eatingState.AssignCustomerAI(this);
        orderingState = new CustomerOrderingState();
        orderingState.AssignCustomerAI(this);
        walkingState.AssignWalkingVariables(agent);

        // pick a random table from available options
        Table[] tables = TableManager.Instance().GetTables();
        do
        {
            int tableIndex = Random.Range(0, tables.Length);
            if (!tables[tableIndex].IsOccupied)
            {
                table = tables[tableIndex];
                table.SetOccupied(true);
            }
        } while (table == null); // !!!! might cause an issue if all tables are full...

        SetNextWalkingDestination(CustomerWalkingState.NextAction.Ordering, table.transform);
        currentstate = walkingState;
    }

    public Table GetTable() => table;

    // Update is called once per frame
    void Update()
    {
        currentstate.RealUpdate();
    }
    
    public void SwitchToWalking()
    {
        currentstate = walkingState;
        currentstate.InitializeState();
    }

    public void SwitchToEating()
    {
        currentstate = eatingState;
        currentstate.InitializeState();
    }

    public void SwitchToOrdering()
    {
        currentstate = orderingState;
        currentstate.InitializeState();
    }

    public void UnAlive()
    {
        Destroy(gameObject);
    }

    public void SetNextWalkingDestination(CustomerWalkingState.NextAction action, Transform destination)
    {
        walkingState.SetDestination(action, destination);
    }
}
