using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMonocleJingle : MonoBehaviour
{
    AudioSource jingle;
    int repeat = 0;
    // Start is called before the first frame update
    void Start()
    {
        jingle = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dollhouse.DollhouseComplete == true) 
        {
            playOnceAndMove();
        }
    }

    void playOnceAndMove()
    {
        if (repeat == 0)
        {
            this.transform.position = new Vector3(4, 0, 0);
            jingle.Play();
            repeat += 1;
        }
    }
}
