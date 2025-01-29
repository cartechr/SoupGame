using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public WaveBluePrint[] Waves;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

[System.Serializable]
public class WaveBluePrint
{
    public int startWave;

    public CustomerAI[] customers;

    public int customerCount;
}