using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Gauntlet = collision.gameObject.GetComponent<Rigidbody>();

        if (collision.gameObject.tag == "Gauntlet" && Gauntlet.velocity.magnitude >= .5) 
        {
            DestroyObject();
        }

    }
}
