using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSpot : MonoBehaviour
{
    private bool occupied = false;

    public void SetOccupied(bool isOccupied)
    {
        occupied = isOccupied;
    }

    public bool IsOccupied => occupied;
}
