using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AISystem : MonoBehaviour
{
    NavMeshAgent navmesh;

    enum AiStates
    {
        None, Soup, Eat, Leave
    };

    [SerializeField] AiStates States = AiStates.None;


    private void Start()
    {
        States = AiStates.Soup;
    }
    private void Update()
    {
        SwitchState();
    }

    void SwitchState()
    {

    }


}

public class GetSoup
{ 
   
}

public class Eat
{

}

public class Leave
{

}