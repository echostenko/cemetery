using CodeBase.Services.Input;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;
        public static IInputService InputService;

        public Game(SceneLoader sceneLoader) => 
            StateMachine = new StateMachine(sceneLoader);
    }
}