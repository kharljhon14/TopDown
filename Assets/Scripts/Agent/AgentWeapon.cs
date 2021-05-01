using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class AgentWeapon : MonoBehaviour
    {
        protected float desiredAngle;

        [SerializeField] protected WeaponRenderer weaponRenderer;
        [SerializeField] protected Weapon currentWeapon;

        private void Awake()
        {
            Initialization();
        }

        private void Initialization()
        {
            weaponRenderer = GetComponentInChildren<WeaponRenderer>();
            currentWeapon = GetComponentInChildren<Weapon>();
        }

        public virtual void AimWeapon(Vector2 pointerPosition)
        {
            Vector3 aimDirection = (Vector3)pointerPosition - transform.position;
            desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            AdjustWeaponRendering();
            transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        }

        protected void AdjustWeaponRendering()
        {
            if(weaponRenderer != null)
            {
                weaponRenderer.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
                weaponRenderer.RenderBehindHead(desiredAngle < 180 && desiredAngle > 0);
            }
        }

        public void Shoot()
        {
            if(currentWeapon != null)
                currentWeapon.TryShooting();
        }

        public void StopShooting()
        {
            if (currentWeapon != null)
                currentWeapon.StopShooting();
        }
    }
}
