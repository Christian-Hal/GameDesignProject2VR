using System;
using System.Collections;
using System.Collections.Generic;
using SerializableCallback;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using static UnityEngine.Rendering.DebugUI.Table;

public class Dollhouse : MonoBehaviour
{ 


    private XRGrabInteractable interactable;
    Rigidbody rb;
    Vector3 lastMouseCoordinate = Vector3.zero;
    public static bool DollhouseComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
    }
    
    void Update()
    {
        // First we find out how much it has moved, by comparing it with the stored coordinate.
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;

        // Then we check if it has moved to the left.
        if(mouseDelta.x < 0) // Assuming a negative value is to the left.
            DollhouseComplete = true;

        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
    }
    
    public void OnSelectEntered(SelectEnterEventArgs arg0) 
    {
        rb.constraints = RigidbodyConstraints.None;
        transform.rotation = arg0.interactorObject.transform.rotation;
    }
}

