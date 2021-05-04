using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class Enemy : MonoBehaviour, IHitable, IAgent, IKnockBack
    {
        [field: SerializeField] public EnemySO EnemyData { get; set; }
        [field: SerializeField] public UnityEvent OnGetHit { get; set; }
        [field: SerializeField] public UnityEvent OnDeath { get; set; }
        [field: SerializeField] public int Health { get; private set; } = 2;
        [field: SerializeField] public EnemyAttack EnemyAttack { get; set; }

        private AgentMovement agentMovement;
        private bool dead = false;

        private void Awake()
        {
            if(EnemyAttack == null)
                EnemyAttack = GetComponent<EnemyAttack>();

            agentMovement = GetComponent<AgentMovement>();
        }

        private void Start()
        {
            Health = EnemyData.MaxHealth;
        }

        public void GetHit(int damage, GameObject damageDealer)
        {
            if (!dead)
            {
                Health--;
                OnGetHit?.Invoke();
                if (Health <= 0)
                {
                    dead = true;
                    OnDeath?.Invoke();
                }
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void PerformAttack()
        {
            if (!dead)
            {
                EnemyAttack.Attack(EnemyData.Damage);
            }
        }

        public void KnockBack(Vector2 direction, float power, float duration)
        {
            agentMovement.KnockBack(direction, power, duration);
        }
    }
}