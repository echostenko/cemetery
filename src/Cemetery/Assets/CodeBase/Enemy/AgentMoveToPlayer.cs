using System;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private const float MinimalDistance = 1;
        
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform heroTransform;

        private IGameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += InitializeHeroTransform;
        }

        private void Update()
        {
            if (HeroNotReached())
                agent.destination = heroTransform.position;
        }

        private void OnDestroy() => 
            _gameFactory.HeroCreated -= InitializeHeroTransform;

        private void InitializeHeroTransform() => 
            heroTransform = _gameFactory.HeroGameObject.transform;

        private bool HeroNotReached() => 
            Vector3.Distance(agent.transform.position, heroTransform.position) >= MinimalDistance;
    }
}