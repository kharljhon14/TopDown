using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Weapons/WeaponData")]
    public class WeaponSO : ScriptableObject
    {
        [field: SerializeField] public BulletSO BulletData { get; set; }
        [field: SerializeField] [field: Range(0, 100)] public int AmmoCapacity { get; set; } = 100;
        [field: SerializeField] public bool AutomaticFire { get; set; } = false;
        [field: SerializeField] [field: Range(.1f, 2f)] public float ShotDelay { get; set; } = .1f;
        [field: SerializeField] [field: Range(0, 10)] public float SpreadAngle { get; set; } = 5f;

        [SerializeField] private bool multiBulletShot = false;
        [SerializeField] [Range(1, 10)] private int bulletToSpawn = 1;

        internal int GetBulletCountToSpawn()
        {
            if (multiBulletShot)
                return bulletToSpawn;

            else
                return 1;
        }
    }
}
