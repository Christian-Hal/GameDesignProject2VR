using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public float breakVel = .5f;
    
    void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Gauntlet = collision.gameObject.GetComponent<Rigidbody>();

        if (collision.gameObject.tag == "Gauntlet" && Gauntlet.velocity.magnitude >= breakVel) 
        {
            DestroyObject();
        }

    }
}
