using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DungeonDoor : MonoBehaviour
{
    public enum State{
        Locked,
        Unlocking,
        Unlocked,
        Open,
        Error,
    }
    private Dictionary<State, Action> StateEnter;
    public State curState = State.Locked;
    public KeyRing.State correctKey;
    public GameObject keyRingObj;
    private KeyRing keyRing;
    public GameObject door;

    // Start is called before the first frame update
    void Start(){
        StateEnter = new(){
            [State.Locked] = StateEnterLocked,
            [State.Unlocking] = StateEnterUnlocking,
            [State.Unlocked] = StateEnterUnlocked,
            [State.Open] = StateEnterOpen,
            [State.Error] = StateEnterError,
        };
        keyRing = keyRingObj.GetComponent<KeyRing>();


    }

    // Update is called once per frame
    void Update(){
        
    }

    private void ChangeState(State newState) {
        if (curState != newState){
            curState = newState;
            StateEnter[newState]();
        }
    }

    public void Interact(){
        if(curState == State.Locked) {
            ChangeState(State.Unlocking);
        }else if (curState == State.Unlocking) { 
            // do nothing
        }else if (curState == State.Unlocked) {
            ChangeState(State.Open);
        }else if (curState == State.Open) { 
            // do nothing
        }else if (curState == State.Error) { 
            // do nothing
        }
    }

    #region state enter methods
    private void StateEnterLocked(){
        print("play sound indicating the door is locked");
    }
    private void StateEnterUnlocking(){
        if(keyRing.curState == KeyRing.State.Idle || keyRing.curState == KeyRing.State.Held){
            ChangeState(State.Locked);
        }else if(keyRing.curState == correctKey) {
            ChangeState(State.Unlocked);
        }else{
            ChangeState(State.Error);
        }
    }
    private void StateEnterUnlocked(){
        print("play sound indicating the door is unlocked now");
    }
    private void StateEnterOpen(){
        door.GetComponent<FinalDoor>().Open();
        print("play sound for opening the door");
    }
    private void StateEnterError(){
        print("play sound indicating the wrong key");
        ChangeState(State.Locked);
    }



    #endregion




}
