using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    List<Interactible> interatibles = new List<Interactible>();

    private void Start()
    {

    }
    public void ReceiveInteractInput()
    {
        if (interatibles.Count == 0)
            return;

        float shortestDistance = Mathf.Infinity;
        Interactible savedInteractible = null;

        foreach (Interactible item in interatibles) 
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
        if (collision.GetComponent<Interactible>() == true)
        {
            interatibles.Add(collision.GetComponent<Interactible>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactible>() == true)
        {
            interatibles.Remove(collision.GetComponent<Interactible>());
        }
    }
}
