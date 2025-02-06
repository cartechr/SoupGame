using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask layerMask;
    Transform highlight;
    public Material highlightMaterial;
    public Material originalMaterialHighlight;
    float maxDistance = 5f;

    private void Update()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Raycast hit: " + hit.transform.name);

            highlight = hit.transform;
            if (highlight.GetComponent<Outline>() != null)
            {
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        }
        else
        {
            highlight = null;
        }

    }

    private void OnDrawGizmos() //Draw the gizmos line for visualisation
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            // Draw the raycast
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * hit.distance);

            // Draw a sphere at the hit point
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 0.1f);
        }

    }

}