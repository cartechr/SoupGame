using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public NavMeshAgent agent;

    //Get Soup Objects
    public GameObject fullSoup;
    private GameObject SpawnedSoup;
    public GameObject Bowl;
    public GameObject SpawnedBowl;


    private CustomerWalkingState walkingState;
    private CustomerEatingState eatingState;
    private CustomerOrderingState orderingState;
    //private CustomerQueueState queueState;
    private CustomerAIState currentstate;

    private Table table;
    private Chair chair;
    private Vector3 savedNavMeshPos; // last pos customer was at in navmesh before sitting

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
        //queueState = new CustomerQueueState();
        //queueState.AssignCustomerAI(this);

        walkingState.AssignWalkingVariables(agent);

        // pick a random table from available options
        Table[] tables = TableManager.Instance().GetTables();

        bool freeTableExists = false;
        foreach (Table table in tables)
        {
            if (!table.IsOccupied)
                freeTableExists = true;
        }
        if (!freeTableExists)
        {
            Debug.LogError("NO FREE TABLE EXISTS, ADD CUSTOMER TO QUEUE");
        }

        do
        {
            int tableIndex = Random.Range(0, tables.Length);
            if (!tables[tableIndex].IsOccupied)
            {
                table = tables[tableIndex];
                table.SetOccupied(true);
            }
        } while (table == null); // !!!! might cause an issue if all tables are full...

        chair = table.GetFreeChair();
        if (chair == null)
            Debug.LogError("There was no free chair, something went wrong...");

        SetNextWalkingDestination(CustomerWalkingState.NextAction.Ordering, chair.transform);
        currentstate = walkingState;
    }

    public Table GetTable() => table;
    public Chair GetChair() => chair;
    public void SetNavMeshAgentActive(bool isActive)
    {
        agent.enabled = isActive;
    }

    public void SaveNavMeshPos()
    {
        savedNavMeshPos = transform.position;
    }
    public void MoveToSavedNavMeshPos()
    {
        transform.position = savedNavMeshPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(agent.steeringTarget - transform.position);
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
    /* public void SwitchToQueue()
     {
         currentstate = queueState;
         currentstate.InitializeState();
     }*/
    public void UnAlive()
    {
        Destroy(gameObject);
    }

    public void SpawnSoup()
    {
       SpawnedSoup = Instantiate(fullSoup, new Vector3(GetTable().transform.position.x, GetTable().transform.position.y + 1, GetTable().transform.position.z), Quaternion.identity);
        Debug.Log("SOUP");

    }

    public void KillSoup()
    {
        Destroy(SpawnedSoup);
    }

    public void SpawnBowl()
    {
       SpawnedBowl = Instantiate(Bowl, new Vector3(GetTable().transform.position.x, GetTable().transform.position.y + 1, GetTable().transform.position.z), Quaternion.identity);

    }

    public void KillBowl()
    {
        Destroy(SpawnedBowl);
    }
    public void SetNextWalkingDestination(CustomerWalkingState.NextAction action, Transform destination)
    {
        walkingState.SetDestination(action, destination);
    }
}
