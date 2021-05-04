using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class RegularBullet : Bullet
    {
        protected Rigidbody2D rb2d;
        private bool isDead = false;
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
            if (isDead)
                return;

            isDead = true;

            IHitable hitable = collision.GetComponent<IHitable>();
            hitable?.GetHit(bulletData.Damage, gameObject);

            if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                HitObstacle(collision);
            }

            else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                HitEnemy(collision);
            }

            Destroy(gameObject);
        }

        private void HitObstacle(Collider2D collision)
        {
            Debug.Log("Hitting Obstacle");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

            if (hit.collider != null)
                Instantiate(bulletData.ImpactObstacleImpact, hit.point, Quaternion.identity);
        }

        private void HitEnemy(Collider2D collision)
        {
            Debug.Log("Hitting Enemy");

            IKnockBack knockBack = collision.GetComponent<IKnockBack>();
            knockBack?.KnockBack(transform.right, bulletData.KnockBackPower, bulletData.KnockBackDelay);

            Vector2 randomOffset = Random.insideUnitCircle * .5f;
            Instantiate(bulletData.ImpactEnemyPrefab, collision.transform.position + (Vector3)randomOffset, Quaternion.identity);
        }
    }
}