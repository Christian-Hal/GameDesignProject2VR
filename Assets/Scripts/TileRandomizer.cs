using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TileRandomizer : MonoBehaviour
{
    public XRBaseInteractable Tile1;
    public XRBaseInteractable Tile2;
    public XRBaseInteractable Tile3;
    public XRBaseInteractable Tile4;
    public XRBaseInteractable Tile5;
    public XRBaseInteractable Tile6;
    public XRBaseInteractable Tile7;
    public XRBaseInteractable Tile8;

    private bool T1Used = false;
    private bool T2Used = false;
    private bool T3Used = false;
    private bool T4Used = false;
    private bool T5Used = false;
    private bool T6Used = false;
    private bool T7Used = false;
    private bool T8Used = false;

    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public GameObject Slot5;
    public GameObject Slot6;
    public GameObject Slot7;
    public GameObject Slot8;
    public GameObject Slot9;



    // Start is called before the first frame update
    void Start(){
        // put the tiles in an array
        XRBaseInteractable[] Tiles = {Tile1, Tile2, Tile3, Tile4, Tile5, Tile6, Tile7, Tile8};
        // put tileBools in an array
        bool[] TileBools = {T1Used, T2Used, T3Used, T4Used, T5Used, T6Used, T7Used, T8Used};
        // put the slots in an array
        GameObject[] Slots = { Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9 };

        // randomly select which slot will be empty
        int skipped = Random.Range(0, Slots.Length);

        // loop through the slots
        for (int i = 0; i < Slots.Length; i++) {
            // skip the empty slot
            if (i != skipped) {
                // randomly select a tile for this slot
                int tile = Random.Range(0, Tiles.Length);
                // check to see if that tile has already been placed, choose another if so
                while (TileBools[tile]) { 
                    tile = Random.Range(0, Tiles.Length);
                }
                // put the tile in the slot
                Slots[i].GetComponent<XRSocketInteractor>().startingSelectedInteractable = Tiles[tile];
                Tiles[tile].GetComponent<Transform>().position = Slots[i].GetComponent<Transform>().Find("TpPos").position;

                // set the tile to true
                TileBools[tile] = true;
            }
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
