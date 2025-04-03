using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSnapZones : MonoBehaviour
{
    public bool SnapZoneEntered = false; // Flag to indicate if the snap zone is entered
    public GameObject TargetObject; // Object that can trigger the snap zone
    private MeshRenderer meshRenderer;
    public Color hoverColor = Color.green; // Color when object hovers
    private Color originalColor;

    void Start()
    {
        // Get the MeshRenderer component and store the original color
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            originalColor = meshRenderer.material.color;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ChangeColor(hoverColor); // Change to hover color
        if (other.gameObject == TargetObject) // Ensure it's the correct object
        {
            Debug.Log("Snap Zone Entered by TargetObject"); 
            SnapZoneEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        ChangeColor(originalColor); // Revert to original color
        if (other.gameObject == TargetObject)
        {
            Debug.Log("Snap Zone Exited by TargetObject"); 
            SnapZoneEntered = false;
        }
    }

    void ChangeColor(Color newColor)
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = newColor;
        }
    }

}
