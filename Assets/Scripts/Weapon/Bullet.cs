using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected BulletSO bulletData;

        public virtual BulletSO BulletData
        {
            get { return bulletData; }
            set { bulletData = value; }
        }

        //[field: SerializeField] public virtual BulletSO BulletData { get; set; }
    }
}