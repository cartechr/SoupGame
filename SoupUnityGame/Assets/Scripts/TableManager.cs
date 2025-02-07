using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    private Table[] tables;

    private static TableManager instance;

    private void Awake()
    {
        // setting up singleton
        if (instance != null && instance != this)
            Destroy(this);
        instance = this;

        tables = GetComponentsInChildren<Table>();
    }

    public static TableManager Instance()
    {
        return instance;
    }

    public Table[] GetTables() => tables;
}
