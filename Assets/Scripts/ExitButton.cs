using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class ExitButton : MonoBehaviour
{
    public GameObject button;
    public string scene = "GameOver";
    XRGrabInteractable interactable;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.isSelected)
        {
            selected = true;
        }
        if (selected && !interactable.isSelected)
        {
            Quit();
            reset();
            selected = false;
        }
        
    }
    
    public void Quit()
    {
        if (button.name.Equals("Quit"))
        {
            Debug.Log("Quitting out of the application");
            Application.Quit();
        }
    }

    public void reset()
    {
        if (button.name.Equals("Reset"))
        {
            Debug.Log("Reseting the application");
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
