namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() => 
            _sceneLoader.Load("Main");

        public void Exit()
        {
        }
    }
}