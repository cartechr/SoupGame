using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnInteract;
    public void Interact()
    {
        OnInteract.Invoke();
    }
}
