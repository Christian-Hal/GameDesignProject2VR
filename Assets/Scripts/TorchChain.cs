using System.Collections;
using System.Collections.Generic;
using Tripolygon.UModelerX.Runtime;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TorchChain : MonoBehaviour
{
    public GameObject[] torches;
    public float timer = 1200f;

    private float gameTimer = 0;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < torches.Length; i++)
        {
            torches[i].transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Stop();
        }
        timer = timer / torches.Length;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer = Time.fixedTime;
        Debug.Log(gameTimer);
        
        if (i >= torches.Length)
        {
            Debug.Log("The game is over");
            // Change the scenes to the game over scene
        }

        if (gameTimer / timer >= i+1)
        {
            torches[i].transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Stop();
            torches[i].transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();

            i++;

        }
    }
}
