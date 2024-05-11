using System;
using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using UnityEngine;

public class BootstrapState : IState
{
    private const string Initial = "Initial";
    
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        RegisterServices();
        _sceneLoader.Load(Initial, onLoaded: OnLoadLevel);
    }
    
    public void Exit()
    {
    }

    private void OnLoadLevel() => 
        _stateMachine.Enter<LoadLevelState>();

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