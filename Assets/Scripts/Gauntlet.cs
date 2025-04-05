using System;
using System.Collections;
using System.Collections.Generic;
using SerializableCallback;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Gauntlet : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;

    int hand = 0;
    XRGrabInteractable interactable;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.isSelected)
        {
            if (hand == 1)
            {
                transform.rotation = LeftHand.transform.rotation;
                transform.position = LeftHand.transform.position;
            }
            if (hand == 2)
            {
                transform.rotation = RightHand.transform.rotation;
                transform.position = RightHand.transform.position;
            }
            
        }
        if (!interactable.isSelected && hand != 0)
        {
            if (hand == 1)
            {
                transform.position = LeftHand.transform.position;
            }
            else
            {
                transform.position = RightHand.transform.position;
            }
            hand = 0;
        }
    }

    public void OnGrab(SelectEnterEventArgs arg0)
    {
        rb.constraints = RigidbodyConstraints.None;
        GameObject interactorObject = arg0.interactorObject.transform.gameObject;
        Debug.Log("The function was called");
        if (interactorObject.CompareTag("LeftHand"))
        {
            hand = 1;
        }
        else if (interactorObject.CompareTag("RightHand"))
        {
            hand = 2;
        }
    }
}

