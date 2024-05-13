using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;

        public Game(SceneLoader sceneLoader, Fade fade) => 
            StateMachine = new StateMachine(sceneLoader, fade, AllServices.Container);
    }
}