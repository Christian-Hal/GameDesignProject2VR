using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabCastleShakeCamera : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    private bool isGrabbed = false;
    private Vector3 previousPosition;
    public CameraShake cameraShake;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;
        previousPosition = transform.position;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
    }

    void Update()
    {
        if (isGrabbed)
        {
            // Check if the object is moving (using velocity)
            if (transform.position != previousPosition)
            {
                // Object is moving
                cameraShake.Shake(5f,1f);
            }
            previousPosition = transform.position;
        }
    }
}