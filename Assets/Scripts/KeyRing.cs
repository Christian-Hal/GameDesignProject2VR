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
    public Animator animator;

    // Start is called before the first frame update
    void Start(){
        StateEnter = new(){
            [State.Idle] = StateEnterIdle,
            [State.Held] = StateEnterHeld,
            [State.Key1] = StateEnterKey1,
            [State.Key2] = StateEnterKey2,
            [State.Key3] = StateEnterKey3,
        };
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void ChangeState(State newState) { 
        if(curState != newState) {
            StateEnter[newState]();
            curState = newState;
        }
    }

    #region interaction methods

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

    #endregion

    #region state enter methods
    private void StateEnterIdle() {
        LowerAll();
        print("play jingling sound");
    }
    private void StateEnterHeld(){
        LowerAll();
        print("play jingling sound");
    }
    private void StateEnterKey1(){
        Key1Up();
        print("play jingling sound");
    }
    private void StateEnterKey2(){
        Key2Up();
        print("play jingling sound");
    }
    private void StateEnterKey3(){
        Key3Up();
        print("play jingling sound");
    }
    #endregion

    #region animation methods

    private void LowerAll() { 
        if(curState == State.Key1) {
            animator.ResetTrigger("To Key 2");
            animator.ResetTrigger("To Key 3");
            animator.ResetTrigger("To Idle");

            animator.SetTrigger("To Key 2");
            animator.SetTrigger("To Key 3");
            animator.SetTrigger("To Idle");
        }
        else if(curState == State.Key2) {
            animator.ResetTrigger("To Key 3");
            animator.ResetTrigger("To Idle");

            animator.SetTrigger("To Key 3");
            animator.SetTrigger("To Idle");
        }else if(curState == State.Key3) {
            animator.ResetTrigger("To Idle");

            animator.SetTrigger("To Idle");
        }
    }

    private void Key1Up() { 
        if(curState == State.Held) {
            animator.ResetTrigger("To Key 1");
            
            animator.SetTrigger("To Key 1");
        }else if (curState == State.Key3) {
            animator.ResetTrigger("To Idle");
            animator.ResetTrigger("To Key 1");

            animator.SetTrigger("To Idle");
            animator.SetTrigger("To Key 1");
        }
        else {
            print("Error: Shouldn't be calling Key1Up from any state other than Held or Key3. The current State is " + curState);
        }
    }

    private void Key2Up() { 
       if(curState == State.Key1) {
            animator.ResetTrigger("To Key 2");
            
            animator.SetTrigger("To Key 2");
       } else{
            print("Error: Shouldn't be calling Key2Up from any state other than Key1. The current state is " + curState);
       }
    }

    private void Key3Up() { 
        if(curState == State.Key2) {
            animator.ResetTrigger("To Key 3");
            
            animator.SetTrigger("To Key 3");
        }else {
            print("Error: Shouldn't be calling Key3UP from any state other than Key3. The current state is " + curState);
        }
    }

    #endregion

}
