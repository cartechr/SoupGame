using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupSpout : MonoBehaviour
{
    [SerializeField]
    private PipeController controller;
    private SpriteRenderer sprite;

    // for enlarging effect
    private bool enlarging = false;
    private float enlargeLerp = 0f;
    private float enlargingMultiplier = 2f;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enlarging)
        {
            enlargeLerp += Time.deltaTime * enlargingMultiplier;
            sprite.transform.localScale = Vector3.Lerp(Vector3.one * 1.5f, Vector3.one, enlargeLerp);
            if (enlargeLerp >= 1f)
                enlarging = false;
        }
    }

    public void TakeSoup()
    {
        controller.TakeSoup();
        Enlarge();
    }

    private void Enlarge()
    {
        enlargeLerp = 0f;
        sprite.transform.localScale = Vector3.one * 1.5f;
        enlarging = true;
    }
}
