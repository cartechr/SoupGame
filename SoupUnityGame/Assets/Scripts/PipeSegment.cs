using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSegment : MonoBehaviour
{
    private MeshRenderer mesh;
    [SerializeField]
    private Material workingMat;
    [SerializeField]
    private Material damagedMat;

    private bool working = true;

    private void Awake()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if (!working)
            return;

        mesh.material = damagedMat;
        working = false;
    }

    public void Fix()
    {
        if (working)
            return;

        mesh.material = workingMat;
        working = true;
    }
}
