using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class AgentStepSound : AudioManager
    {
        [SerializeField] protected AudioClip stepClip;

        public void PlayStepSound()
        {
            PlayClipWithVariablePitch(stepClip);
        }
    }
}
