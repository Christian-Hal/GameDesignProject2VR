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

    #region state enter methods
    private void StateEnterIdle() {
        
    }
    private void StateEnterHeld(){

    }
    private void StateEnterKey1(){

    }
    private void StateEnterKey2(){

    }
    private void StateEnterKey3(){

    }
    #endregion


}
