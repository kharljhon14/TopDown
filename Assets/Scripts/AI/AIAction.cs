using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class AIAction : MonoBehaviour
    {
        protected AIActionData aiActionData;
        protected AIMovementData aiMovementData;
        protected EnemyBrain enemyBrain;

        private void Awake()
        {
            aiActionData = transform.root.GetComponentInChildren<AIActionData>();
            aiMovementData = transform.root.GetComponentInChildren<AIMovementData>();
            enemyBrain = transform.root.GetComponent<EnemyBrain>();
        }

        public abstract void TakeAction();
    }
}