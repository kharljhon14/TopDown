using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class Enemy : MonoBehaviour, IHitable
    {
        [field: SerializeField] public EnemySO EnemyData { get; set; }
        [field: SerializeField] public UnityEvent OnGetHit { get; set; }
        [field: SerializeField] public UnityEvent OnGetDeath { get; set; }
        [field: SerializeField] public int Health { get; private set; } = 2;

        private void Start()
        {
            Health = EnemyData.MaxHealth;
        }

        public void GetHit(int damage, GameObject damageDealer)
        {
            Health--;
            OnGetHit?.Invoke();
            if(Health <= 0)
            {
                OnGetDeath?.Invoke();
                StartCoroutine(WaitToDie());
            }
        }

        private IEnumerator WaitToDie()
        {
            yield return new WaitForSeconds(.3f);
            Destroy(gameObject);
        }
    }
}