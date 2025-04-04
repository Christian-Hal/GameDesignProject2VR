using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BrickManager : MonoBehaviour
{
    private int totalBricksCorrect;
    // Start is called before the first frame update
    void Start()
    {
        totalBricksCorrect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalBricksCorrect >= 5)
        {
            print("ALL CORRECT!!!");
        }
    }

    public void correctBrick(int num)
    {
        totalBricksCorrect += num;
    }
}
