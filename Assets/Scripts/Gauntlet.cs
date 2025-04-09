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
    public GameObject LeftHand;
    public GameObject RightHand;

    int hand = 0;
    private XRGrabInteractable interactable;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
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
            transform.Rotate(90, 0, 0);

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

    public void OnSelectEntered(SelectEnterEventArgs arg0) 
    {
        rb.constraints = RigidbodyConstraints.None;
        GameObject interactorObject = arg0.interactorObject.transform.gameObject;
        if (interactorObject.CompareTag("LeftHand"))
        {
            hand = 1;
        }
        else if (interactorObject.CompareTag("RightHand"))
        {
            hand = 2;
        }
    }
    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }
}

