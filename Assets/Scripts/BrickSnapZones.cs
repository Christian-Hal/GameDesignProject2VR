using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class BrickSnapZones : MonoBehaviour
{
    public GameObject TargetObject; // Object that can trigger the snap zone
    private MeshRenderer meshRenderer;
    private Color originalColor;
    public GameObject manager;
    public int brickNum;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TargetObject) // Ensure it's the correct object
        {
            Debug.Log("Snap Zone Entered by TargetObject"); 
            manager.GetComponent<BrickManager>().correctBrick(brickNum);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == TargetObject)
        {
            Debug.Log("Snap Zone Exited by TargetObject");
            manager.GetComponent<BrickManager>().correctBrick(brickNum);
        }
    }
}
