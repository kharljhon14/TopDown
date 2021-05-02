using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class Player : MonoBehaviour, IAgent, IHitable
    {
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public UnityEvent OnDeath { get; set; }
        [field: SerializeField] public UnityEvent OnGetHit { get; set; }

        private bool dead = false;

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
                    StartCoroutine(DeathCoroutine());
                }
            }
        }
        
        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}