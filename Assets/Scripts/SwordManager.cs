using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SwordManager : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    public bool five;
    private bool all;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
        two = false;
        three = false;
        four = false;
        five = false;

        all = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(three)
        {
            print("ALL ARE CORRECT");
        }
    }

    public void correctSword(int num)
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
