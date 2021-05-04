using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(Animator))]
    public class AgentAnimation : MonoBehaviour
    {
        protected Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void SetMovingAnimation(bool value)
        {
            anim.SetBool("Moving", value);
        }

        public void AnimateAgent(float velocity)
        {
            SetMovingAnimation(velocity > 0);
        }

        public void PlayDeathAnimation()
        {
            anim.SetTrigger("Death");
        }
    }
}
