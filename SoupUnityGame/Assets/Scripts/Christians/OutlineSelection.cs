using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask layerMask;
    [Tooltip("Variable to calculate distance between camera and raycast hit distance")]
    public float maxDistance = 100f;
    public float distanceBetween; //Global variable to store the Vector3.Distance variable to calculate distance between camera and raycast hit.distance
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Raycast hit: " + hit.transform.name);

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