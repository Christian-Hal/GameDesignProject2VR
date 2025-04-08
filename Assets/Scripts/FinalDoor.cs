using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalDoor : MonoBehaviour
{
    public GameObject Password;
    public int[] input;
    // Start is called before the first frame update
    void Start()
    {
        input = new int[4];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = 0;
        }
        if (Time.fixedTime > 3) // if the password is correct :3
        {
            Open();
        }
    }

    void Open()
    {
        Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.right);
        transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, .001f); 
    }
}
