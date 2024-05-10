using System;
using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using UnityEngine;

public class BootstrapState : IState
{
    private readonly StateMachine _stateMachine;

    public BootstrapState(StateMachine stateMachine) => 
        _stateMachine = stateMachine;

    public void Enter() => 
        RegisterServices();

    public void Exit()
    {
        throw new NotImplementedException();
    }
    
    private void RegisterServices() => 
        Game.InputService = InitializeInputService();

    private static IInputService InitializeInputService()
    {
        if (Application.isEditor)
            return new StandaloneInputService();
        else
            return new MobileInputService();
    }
}