using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        protected EnemyBrain enemyBrain;
        protected bool waitForNextAttack;

        [field: SerializeField] public float AttackDelay { get; private set; } = 1f;

        private void Awake()
        {
            enemyBrain = GetComponent<EnemyBrain>();
        }

        public abstract void Attack(int damage);

        protected IEnumerator WaitForNextAttackCoroutine()
        {
            waitForNextAttack = true;
            yield return new WaitForSeconds(AttackDelay);
            waitForNextAttack = false;
        }

        protected GameObject GetTarget()
        {
            return enemyBrain.Target;
        }
    }
}
