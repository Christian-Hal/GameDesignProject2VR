using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalConstrain : MonoBehaviour
{
    public GameObject obj;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = obj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockX() {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
    }

    public void LockZ() {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }
    public void Unlock() {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
}
