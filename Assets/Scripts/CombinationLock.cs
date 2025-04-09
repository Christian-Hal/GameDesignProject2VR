using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CombinationLock : MonoBehaviour
{
    public int[] password = { 4, 7, 5, 7 };
    private int[] entered = { 0, 0, 0, 0 };
    public GameObject[] numbers;
    public GameObject door;
    public GameObject door2;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            XRBaseInteractable button = numbers[i].GetComponent<XRBaseInteractable>();
            int value = int.Parse(numbers[i].name);
            button.selectEntered.AddListener((arg) => OnNumberPressed(value));
        }
    }


    // If youre reading this... i had help for this function and line 18. TY chatgpt
    private void OnNumberPressed(int val)
    {
        for(int i = entered.Length - 1; i > 0; i--)
        {
            entered[i] = entered[i-1];
        }
        entered[0] = val;
        if (password.SequenceEqual(entered))
        {
            door.GetComponent<FinalDoor>().Open();
            door2.GetComponent<FinalDoor>().Open();
            
        }
    }
}
