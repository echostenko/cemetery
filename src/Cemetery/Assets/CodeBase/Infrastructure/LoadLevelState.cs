using CodeBase.CameraLogic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string HeroPath = "Hero/hero";
        private const string HudPath = "Hud/Hud";
        
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            var spawnPoint = GameObject.FindWithTag("InitialPoint");
            var hero =  Instantiate(HeroPath, spawnPoint.transform.position);
            Instantiate(HudPath);
            CameraFollow(hero);
        }

        private void CameraFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private GameObject Instantiate(string path, Vector3 spawnPoint)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
        }
    }
}