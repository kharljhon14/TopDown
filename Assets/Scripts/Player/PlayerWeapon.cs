using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class PlayerWeapon : AgentWeapon
    {
        [SerializeField] private UIAmmo uiAmmo = null;

        public bool AmmoFull { get => currentWeapon != null && currentWeapon.AmmoFull; }

        private void Start()
        {
            if (currentWeapon != null)
            {
                currentWeapon.OnAmmoChange.AddListener(uiAmmo.UpdateBulletText);
                uiAmmo.UpdateBulletText(currentWeapon.Ammo);
            }
        }

        public void AddAmmo(int amount)
        {
            if (currentWeapon != null)
                currentWeapon.Ammo += amount;
        }
    }
}