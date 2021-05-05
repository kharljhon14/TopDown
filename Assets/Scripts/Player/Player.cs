using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class Player : MonoBehaviour, IAgent, IHitable
    {
        [SerializeField] private int maxHealth;
        private int health;
        public int Health 
        { 
            get => health; 
            set 
            { 
                health = Mathf.Clamp(value, 0, maxHealth); 
                UIHealth.UpdateUI(health); 
            } 
        }

        [field: SerializeField] public UnityEvent OnDeath { get; set; }
        [field: SerializeField] public UnityEvent OnGetHit { get; set; }
        [field: SerializeField] public UIHealth UIHealth { get; set; }

        private bool dead = false;
        private PlayerWeapon playerWeapon;

        private void Awake()
        {
            playerWeapon = GetComponentInChildren<PlayerWeapon>();
        }

        private void Start()
        {
            Health = maxHealth;
            UIHealth.Initialize(Health);   
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Items"))
            {
                Resouce resource = collision.gameObject.GetComponent<Resouce>();

                if(resource != null)
                {
                    switch (resource.resouceType.ResouceEnum)
                    {
                        case ResouceType.Health:
                            if (Health >= maxHealth)
                                return;

                            Health += resource.resouceType.GetAmount();
                            resource.PickupResouce();
                            break;

                        case ResouceType.Ammo:
                            if (playerWeapon.AmmoFull)
                                return;

                            playerWeapon.AddAmmo(resource.resouceType.GetAmount());
                            resource.PickupResouce();
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}