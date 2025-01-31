using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAIManager : MonoBehaviour
{
    [SerializeField]
    private Transform customerSpawn;

    private static CustomerAIManager instance;

    private void Awake()
    {
        // setting up singleton
        if (instance != null && instance != this)
            Destroy(this);
        instance = this;
    }

    public static CustomerAIManager Instance()
    {
        return instance;
    }

    public Transform GetCustomerSpawnPoint() => customerSpawn;
}
