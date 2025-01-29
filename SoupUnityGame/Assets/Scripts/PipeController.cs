using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private SoupPot soupPot;
    private List<PipeSegment> segments = new List<PipeSegment>();
    private float segmentDamageChance = 0f; // between 0 and 1
    //private float damageMultiplier = 

    // Start is called before the first frame update
    void Start()
    {
        // set up all segments that are part of this pipe
        foreach (PipeSegment segment in transform.GetComponentsInChildren<PipeSegment>())
            segments.Add(segment);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeSoup()
    {
        if (soupPot.GetPotFullness() == 0f)
            return;

        soupPot.TakeServing();
        DamageSegment();
    }

    private void DamageSegment()
    {
        if (Random.Range(0f, 1f) < segmentDamageChance)
        {
            segments[Mathf.RoundToInt(Random.Range(0f, segments.Count - 1))].Damage();
        }

        segmentDamageChance += 0.1f;
    }
}
