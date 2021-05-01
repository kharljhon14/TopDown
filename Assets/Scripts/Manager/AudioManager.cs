using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioManager : MonoBehaviour
    {
        [SerializeField] protected float randomPitch = .05f;

        protected AudioSource audioSource;
        protected float basePitch;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            basePitch = audioSource.pitch;
        }

        protected void PlayClipWithVariablePitch(AudioClip clip)
        {
            float pitch = Random.Range(-randomPitch, randomPitch);
            audioSource.pitch = basePitch + pitch;
            PlayClip(clip);
        }

        protected void PlayClip(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}