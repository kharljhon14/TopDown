using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class WeaponAudio : AudioManager
    {
        [SerializeField] private AudioClip shootBulletClip = null;
        [SerializeField] private AudioClip outOfBulletsClip = null;

        public void PlayShootSound()
        {
            PlayClip(shootBulletClip);
        }

        public void PlayOutOfBulletsSound()
        {
            PlayClip(outOfBulletsClip);
        }
    }
}
