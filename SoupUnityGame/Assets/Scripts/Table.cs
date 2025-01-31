using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private PipeController[] pipes;
    private bool occupied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PipeController[] GetPipes() => pipes;

    public void SetOccupied(bool isOccupied)
    {
        occupied = isOccupied;
    }

    public bool IsOccupied => occupied;
}
