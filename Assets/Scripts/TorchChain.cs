using System.Collections;
using System.Collections.Generic;
using Tripolygon.UModelerX.Runtime;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorchChain : MonoBehaviour
{
    public GameObject[] torches;
    public float timer = 1200f;
    public string endScene = "GameOver";

    private float gameTimer = 0;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = timer / torches.Length;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        Debug.Log(gameTimer);
        
        if (i >= torches.Length)
        {
            Debug.Log("The game is over");
            SceneManager.LoadScene(endScene, LoadSceneMode.Single);
            // Change the scenes to the game over scene
        }

        if (gameTimer / timer >= i+1)
        {
            torches[i].transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Stop();
            i++;

        }
    }
}
