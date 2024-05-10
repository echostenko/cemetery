using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this)
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            var state = _states[typeof(IState)];
            _activeState = state;
            state.Enter();
        }
    }
}