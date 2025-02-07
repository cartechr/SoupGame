using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private PipeController[] pipes;
    private bool occupied = false;
    private Chair[] chairs;

    // Start is called before the first frame update
    void Awake()
    {
        // set up initial empty chairs
        chairs = GetComponentsInChildren<Chair>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PipeController[] GetPipes() => pipes;

    public void SetOccupied(bool isOccupied)
    {
        occupied = isOccupied;
        if (!occupied)
        {
            // set all chairs to empty
            foreach (Chair chair in chairs)
                chair.SetIsOccupied(false);
        }
    }

    public Chair GetFreeChair()
    {
        Chair freeChair = null;
        foreach (Chair chair in chairs)
        {
            // chair is empty
            if (chair.IsOccupied() == false)
            {
                chair.SetIsOccupied(true);
                freeChair = chair;
                break;
            }
        }
        return freeChair;
    }

    public bool IsOccupied => occupied;
}
