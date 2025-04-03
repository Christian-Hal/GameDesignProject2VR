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
        curState = State.Locked;
        print("play sound indicating the door is locked");
    }
    private void StateEnterUnlocking(){
        curState = State.Unlocking;
        if(keyRing.curState == KeyRing.State.Idle || keyRing.curState == KeyRing.State.Held){
            ChangeState(State.Locked);
        }else if(keyRing.curState == correctKey) {
            ChangeState(State.Unlocked);
        }else{
            ChangeState(State.Error);
        }
    }
    private void StateEnterUnlocked(){
        curState = State.Unlocked;
        print("play sound indicating the door is unlocked now");
    }
    private void StateEnterOpen(){
        print("play animation for opening the door");
        print("play sound for opening the door");
        curState = State.Open;
    }
    private void StateEnterError(){
        curState = State.Error;
        print("play sound indicating the wrong key");
        ChangeState(State.Locked);
    }



    #endregion




}
