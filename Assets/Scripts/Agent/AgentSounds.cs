using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class AgentSounds : AudioManager
    {
        [SerializeField] private AudioClip hitClip;
        [SerializeField] private AudioClip deathClip;
        [SerializeField] private AudioClip voiceLineClip;

        public void PlayHitSound()
        {
            PlayClipWithVariablePitch(hitClip);
        }

        public void PlayDeathSound()
        {
            PlayClip(deathClip);
        }

        public void PlayVoiceSound()
        {
            PlayClipWithVariablePitch(voiceLineClip);
        }
    }
}
