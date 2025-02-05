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
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Raycast hit: " + hit.transform.name);

            highlight = hit.transform;
            if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
            {
                originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
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