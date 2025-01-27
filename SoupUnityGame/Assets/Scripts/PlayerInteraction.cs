using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    List<Interactable> interactables = new List<Interactable>();

    private void Start()
    {

    }
    public void ReceiveInteractInput()
    {
        if (interactables.Count == 0)
            return;

        float shortestDistance = Mathf.Infinity;
        Interactable savedInteractible = null;

        foreach (Interactable item in interactables) 
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                savedInteractible = item;
            }
        }
        savedInteractible.Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>() == true)
        {
            interactables.Add(collision.GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>() == true)
        {
            interactables.Remove(collision.GetComponent<Interactable>());
        }
    }
}
