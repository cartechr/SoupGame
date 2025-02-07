using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPot : MonoBehaviour
{
    private float potFullness = 0f; // 100f is full, 0f is empty
    private float servingAmount = 20f;

    private void Start()
    {
        RefillPot();
    }

    private void UpdateFullnessGraphics()
    {
        // come back and update pot visuals here to reflect fullness level!!
    }    

    public void TakeServing()
    {
        if (potFullness < servingAmount)
        {
            Debug.Log("out of soup!!");
            return;
        }
        potFullness -= servingAmount;
        UpdateFullnessGraphics();
    }

    public void RefillPot()
    {
        potFullness = 100f;
        UpdateFullnessGraphics();
    }

    public float GetPotFullness() => potFullness;
}
