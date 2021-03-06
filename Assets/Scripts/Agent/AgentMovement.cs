using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AgentMovement : MonoBehaviour
    {
        [field: SerializeField] public MovementSO movementData { get; set; }
        [field: SerializeField] public UnityEvent<float> OnVelocityChanged { get; set; }

        [SerializeField] protected float currentVelocity = 3f;

        protected Rigidbody2D rb2d;
        protected Vector2 movementDirection;
        protected bool isKnockedBack = false;
        

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            OnVelocityChanged?.Invoke(currentVelocity);

            if(!isKnockedBack)
                rb2d.velocity = currentVelocity * movementDirection.normalized;
        }

        public void MoveAgent(Vector2 movementInput)
        {
            if(movementInput.magnitude > 0)
            {
                if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                    currentVelocity = 0;

                movementDirection = movementInput.normalized;
            }
                
            currentVelocity = CalculateSpeed(movementInput);

            //rb2d.velocity = movementInput.normalized * currentVelocity;
        }

        private float CalculateSpeed(Vector2 movementInput)
        {
            if(movementInput.magnitude > 0)
                currentVelocity += movementData.accelaration * Time.deltaTime;

            else
                currentVelocity -= movementData.deaccelaration * Time.deltaTime;

            return Mathf.Clamp(currentVelocity, 0, movementData.maxSpeed);
        }

        public void StopImmedietly()
        {
            currentVelocity = 0;
            rb2d.velocity = Vector2.zero;
        }

        public void KnockBack(Vector2 direction, float power, float duration)
        {
            if (!isKnockedBack)
            {
                isKnockedBack = true;
                StartCoroutine(KnockBackCoroutine(direction, power, duration));
            }
        }

        public void ResetKnockBack()
        {
            StopAllCoroutines();
            StopCoroutine("KnockBackCoroutine");
            ResetKnockBackValues();
        }

        private IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration)
        {
            rb2d.AddForce(direction.normalized * power, ForceMode2D.Impulse);
            yield return new WaitForSeconds(duration);
            ResetKnockBackValues();
        }

        private void ResetKnockBackValues()
        {
            isKnockedBack = false;
            currentVelocity = 0;
            rb2d.velocity = Vector2.zero;
        }
    }
}
