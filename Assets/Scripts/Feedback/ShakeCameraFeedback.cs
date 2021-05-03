using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ShakeCameraFeedback : Feedback
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] [Range(0, 5)] private float amplitude = 1f;
        [SerializeField] [Range(0, 5)] private float intensity = 1f;
        [SerializeField] [Range(0, 1)] private float duration = 0.1f;

        private CinemachineBasicMultiChannelPerlin noise;

        private void Start()
        {
            if(virtualCamera == null)
                virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

            noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public override void CompletePreviousFeedback()
        {
            StopAllCoroutines();
            noise.m_AmplitudeGain = 0;
        }

        public override void CreateFeedback()
        {
            noise.m_AmplitudeGain = amplitude;
            noise.m_FrequencyGain = intensity;
            StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            for (float i = duration; i > 0; i -= Time.deltaTime)
            {
                noise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration);

                yield return null;
            }

            noise.m_AmplitudeGain = 0;
        }
    }
}