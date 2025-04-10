using System;
using System.Collections;
using System.Collections.Generic;
using SerializableCallback;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using static UnityEngine.Rendering.DebugUI.Table;

public class Gauntlet : MonoBehaviour
{ 


    private XRGrabInteractable interactable;
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
    }
    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }
}

