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


    public static bool DollhouseComplete = false;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor interactor = null;
    private XRGrabInteractable interactable;
    public bool IsGrabbing;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
    }
    
    public void OnSelectEntered(SelectEnterEventArgs arg0) 
    {
        rb.constraints = RigidbodyConstraints.None;
        transform.rotation = arg0.interactorObject.transform.rotation;
        DollhouseComplete = true;

    }
}

