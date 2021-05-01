using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace TopDownShooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected GameObject muzzle;
        [SerializeField] protected int ammo = 10;
        [SerializeField] protected WeaponSO weaponSO;
        [SerializeField] protected bool reloadCoroutine = false;

        public int Ammo
        {
            get { return ammo; }
            set 
            {
                ammo = Mathf.Clamp(value, 0, weaponSO.AmmoCapacity);
            }
        }

        public bool AmmoFull { get => Ammo >= weaponSO.AmmoCapacity; }

        protected bool isShooting = false;

        [field: SerializeField] public UnityEvent OnShoot { get; set; }
        [field: SerializeField] public UnityEvent OnShootNoAmmo { get; set; }

        private void Start()
        {
            Ammo = weaponSO.AmmoCapacity;
        }

        private void Update()
        {
            UseWeapon();
        }

        private void UseWeapon()
        {
            if(isShooting && !reloadCoroutine)
            {
                if(Ammo > 0)
                {
                    Ammo--;
                    OnShoot?.Invoke();

                    for (int i = 0; i < weaponSO.GetBulletCountToSpawn(); i++)
                    {
                        ShootBullet();
                    }
                }

                else
                {
                    isShooting = false;
                    OnShootNoAmmo?.Invoke();
                    return;
                }

                FinishShooting();
            }
        }

        private void FinishShooting()
        {
            StartCoroutine(DelayNextShot());

            if (!weaponSO.AutomaticFire)
                isShooting = false;
        }

        protected IEnumerator DelayNextShot()
        {
            reloadCoroutine = true;
            yield return new WaitForSeconds(weaponSO.ShotDelay);
            reloadCoroutine = false;
        }

        private void ShootBullet()
        {
            SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
        }

        private void SpawnBullet(Vector3 position, Quaternion rotation)
        {
            GameObject bulletPrefab = Instantiate(weaponSO.BulletData.BulletPrefab, position, rotation);
            bulletPrefab.GetComponent<Bullet>().BulletData = weaponSO.BulletData;
        }

        private Quaternion CalculateAngle(GameObject muzzle)
        {
            float spread = Random.Range(-weaponSO.SpreadAngle, weaponSO.SpreadAngle);
            Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));

            return muzzle.transform.rotation * bulletSpreadRotation;
        }

        public void TryShooting()
        {
            isShooting = true;
        }

        public void StopShooting()
        {
            isShooting = false;
        }

        public void ReloadGun(int ammo)
        {
            Ammo += ammo;
        }
    }
}
