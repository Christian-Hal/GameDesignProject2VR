using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Glass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camOffset = mainCamera.transform.position - Glass.transform.position;

        // Mirror the position: put camera B on the other side of the glass
        transform.position = Glass.transform.position - camOffset;

        Vector3 direction = mainCamera.transform.position - Glass.transform.position;

        Quaternion rotation = Quaternion.LookRotation(-direction);
        transform.rotation = rotation;


    }
}
