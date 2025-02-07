using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    private bool isOccupied = false;

    public bool IsOccupied() => isOccupied;
    public void SetIsOccupied(bool _isOccupied) => isOccupied = _isOccupied;
}
