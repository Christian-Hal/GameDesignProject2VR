using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Gauntlet : MonoBehaviour
{

    Rigidbody rb;
    private bool isGrabbed = false;
    XRGrabInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
       interactable = GetComponent<XRGrabInteractable>();
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.isSelected && !isGrabbed)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnEnable()
    {
        
    }
}
