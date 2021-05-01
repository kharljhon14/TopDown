using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WeaponRenderer : MonoBehaviour
    {
        [SerializeField] protected int playerSortingOrder = 0;
        protected SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        public void FlipSprite(bool value)
        {
            int flipModifier = value ? -1 : 1;
            transform.localScale = new Vector3(transform.localScale.x, flipModifier * Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
  
        public void RenderBehindHead(bool value)
        {
            if (value)
                sr.sortingOrder = playerSortingOrder - 2;

            else
                sr.sortingOrder = playerSortingOrder + 2;
        }
    }
}
