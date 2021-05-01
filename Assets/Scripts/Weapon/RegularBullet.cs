using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class RegularBullet : Bullet
    {
        protected Rigidbody2D rb2d;

        public override BulletSO BulletData 
        {   
            get => base.BulletData;

            set 
            {
                base.BulletData = value;
                rb2d = GetComponent<Rigidbody2D>();

                rb2d.drag = BulletData.Friction;
            } 
        }

        private void FixedUpdate()
        {
            if(rb2d != null && BulletData != null)
            {
                rb2d.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHitable hitable = collision.GetComponent<IHitable>();
            hitable?.GetHit(bulletData.Damage, gameObject);

            if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                HitObstacle();
            }

            else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                HitEnemy();
            }

            Destroy(gameObject);
        }

        private void HitObstacle()
        {
            Debug.Log("Hitting Obstacle");
        }

        private void HitEnemy()
        {
            Debug.Log("Hitting Enemy");
        }
    }
}