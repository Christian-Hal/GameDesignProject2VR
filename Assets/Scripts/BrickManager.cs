using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class BrickManager : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    public bool five;
    private bool all;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        all = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (one == true && two == true && three == true && four == true && five == true && all == false)
        {
            all = true;
            print("ALL ARE CORRECT");
            door.GetComponent<Animator>().Play("Door Open Animation");
            //door.GetComponent<Animation>().Play();
        }
    }

    public void correctBrick(int num)
    {
        switch(num) {
            case 1:
                one = !one;
                break;
            case 2:
                two = !two;
                break;
            case 3:
                three = !three;
                break;
            case 4:
                four = !four;
                break;
            case 5:
                five = !five;
                break;
        }
    }
}
