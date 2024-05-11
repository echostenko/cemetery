using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public StateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader)
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            var state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}