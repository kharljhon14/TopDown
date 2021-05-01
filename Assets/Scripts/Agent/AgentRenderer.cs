using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AgentRenderer : MonoBehaviour
    {
        protected SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        public void FaceDirection(Vector2 pointerInput)
        {
            Vector3 direction = (Vector3)pointerInput - transform.position;
            Vector3 result = Vector3.Cross(Vector2.up, direction);

            if (result.z > 0)
                sr.flipX = true;

            else if (result.z < 0)
                sr.flipX = false;
        }
    }
}

