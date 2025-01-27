using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSegment : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private Color workingColor;
    [SerializeField]
    private Color damagedColor;

    private bool working = true;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if (!working)
            return;

        sprite.color = damagedColor;
        working = false;
    }

    public void Fix()
    {
        if (working)
            return;

        sprite.color = workingColor;
        working = true;
    }
}
