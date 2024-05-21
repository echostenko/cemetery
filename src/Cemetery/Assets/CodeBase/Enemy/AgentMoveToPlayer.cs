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
        
        private Transform _heroTransform;
        private IGameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += OnHeroCreated;
        }

        private void Update()
        {
            if (_heroTransform == null) 
                return;
            
            if (HeroNotReached())
                agent.destination = _heroTransform.position;
        }

        private void OnHeroCreated()
        {
            _gameFactory.HeroCreated -= InitializeHeroTransform;
            InitializeHeroTransform();
        }

        private void InitializeHeroTransform() => 
            _heroTransform = _gameFactory.HeroGameObject.transform;

        private bool HeroNotReached() => 
            Vector3.Distance(agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}