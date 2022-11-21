﻿using UnityEngine;
using UnityEngine.AI;

namespace Something.Scripts.Something.AI
{
    public class SimpleEnemyMover : IEnemyMover
    {
        private NavMeshAgent _navMeshAgent;
        private float _speed;

        public SimpleEnemyMover(NavMeshAgent navMeshAgent, float speed)
        {
            _navMeshAgent = navMeshAgent;
            _speed = speed;
        }

        private void Initialize()
        {
            _navMeshAgent.acceleration = _speed;
        }

        public void Move(Vector3 to)
        {
            _navMeshAgent.SetDestination(to);
        }

        public void StandBy(Vector3 to)
        {
            var position = Random.insideUnitSphere * to.magnitude;
            _navMeshAgent.SetDestination(position);
        }

        public void Stand(Vector3 to)
        {
            _navMeshAgent.Stop();
        }

        public void StopMoving()
        {
            _navMeshAgent.Stop();
        }
    }
}