using System.Collections.Generic;
using UnityEngine;

namespace FGT.Prototypes.StateMachine
{
    public class StateMachine
    {
        IState _currentState;
        Dictionary<string, IState> _states = new Dictionary<string, IState>();

        public void AddState(string stateName, IState state)
        {
            _states[stateName] = state;
            state.StateMachine = this;
        }

        public void ChangeState(string stateName)
        {
            if (!_states.ContainsKey(stateName))
            {
                Debug.Log($">>>> statemachine does not contain state: {stateName}");
                return;
            }

            _currentState?.Exit();
            _currentState = _states[stateName];
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState.Execute();
        }
    }
}
