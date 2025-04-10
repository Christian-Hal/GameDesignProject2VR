using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalDoor : MonoBehaviour
{
    public float OpenSpeed = 0.005f;
    public float timeToOpen = 10;
    public Vector3 moveVec = Vector3.up;

    private bool open = false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Opening();
        }
    }

    public void Open()
    {
        open = true;
    }

    public void Opening()
    {
        Quaternion newRotation = Quaternion.AngleAxis(-90, moveVec);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, OpenSpeed);
        timer += Time.deltaTime;
        if (timer > timeToOpen)
        {
            open = false;
        }
    }
}
