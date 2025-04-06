using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyRing : MonoBehaviour
{
    public enum State{
        Idle,
        Held,
        Key1,
        Key2,
        Key3,
    }
    private Dictionary<State, Action> StateEnter;
    public State curState = State.Idle;

    // Start is called before the first frame update
    void Start(){
        StateEnter = new(){
            [State.Idle] = StateEnterIdle,
            [State.Held] = StateEnterHeld,
            [State.Key1] = StateEnterKey1,
            [State.Key2] = StateEnterKey2,
            [State.Key3] = StateEnterKey3,
        };
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void ChangeState(State newState) { 
        if(curState != newState) {
            curState = newState;
            StateEnter[newState]();
        }
    }

    public void Flip() {
        print("Flipping keyring");
        if (curState == State.Held) {
            print("going to key 1 from held");
            ChangeState(State.Key1);
        }else if (curState == State.Key1) {
            print("going to key 2 from key 1");
            ChangeState(State.Key2);
        }else if (curState == State.Key2) {
            print("going to key 3 from key 2");
            ChangeState(State.Key3);
        }else if (curState == State.Key3){
            print("going to key 1 from key 3");
            ChangeState(State.Key1);
        } else{
            print("error. Current state is " + curState + " going nowhere");
        }
    }

    public void PickUp(){
        print("Picking up keys");
        if(curState == State.Idle) {
            ChangeState(State.Held);
        }
    }

    public void PutDown() {
        print("Putting down keys");
        ChangeState(State.Idle);
    }

    #region state enter methods
    private void StateEnterIdle() {
        print("play animation to lower all keys");
        print("play jingling sound");
    }
    private void StateEnterHeld(){
        print("play animation to lower all keys");
        print("play jingling sound");
    }
    private void StateEnterKey1(){
        print("play animation to raise key 1");
        print("play jingling sound");
    }
    private void StateEnterKey2(){
        print("play animation to raise key 2");
        print("play jingling sound");
    }
    private void StateEnterKey3(){
        print("play animation to raise key 3");
        print("play jingling sound");
    }
    #endregion


}
