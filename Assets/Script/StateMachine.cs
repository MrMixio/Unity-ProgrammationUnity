using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        _currentState = GetComponent<State>();
        _currentState.Enter();
    }

    private void Update()
    {
        _currentState.Tick();
    }

    public void ChangeState(State newInitialisation)
    {
        _currentState.Exit();
        _currentState = newInitialisation;  
        _currentState.Enter();
    }
}
