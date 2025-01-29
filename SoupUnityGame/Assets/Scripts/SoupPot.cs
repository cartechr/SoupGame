using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPot : MonoBehaviour
{
    private float potFullness = 0f; // 100f is full, 0f is empty
    private float servingAmount = 20f;

    [SerializeField]
    private GameObject fullnessBar;

    private void Start()
    {
        UpdateFullnessGraphics();
    }

    private void UpdateFullnessGraphics()
    {
        fullnessBar.transform.localScale = new Vector3(potFullness / 100f, 
            fullnessBar.transform.localScale.y, fullnessBar.transform.localScale.z);
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
