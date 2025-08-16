using System.Collections.Generic;
using UnityEngine;

namespace FGT.Prototypes.SimpleStateMachine
{
    public class StateMachine
    {
        IState _currentState;
        Dictionary<string, IState> _states = new Dictionary<string, IState>();
        IState _newState;

        public void AddState(string stateName, IState state)
        {
            _states[stateName] = state;
            state.StateMachine = this;
        }

        public void ChangeState(string stateName)
        {
            if (!_states.ContainsKey(stateName))
            {
                Debug.LogWarning($">>>> statemachine does not contain state: {stateName}");
                return;
            }

            _newState = _states[stateName];
            if (_currentState == null)
                _currentState = _newState;
        }

        public void Update()
        {
            
            if (_currentState == null)
            {
                Debug.LogWarning($">>>> _currentState == null. Can't Update");
                return;
            }

            if (_newState != null &&
                _newState != _currentState)
            {
                _currentState?.Exit();
                _currentState = _newState;
                _currentState.Enter();
            }

            _currentState.Execute();
        }
    }
}
