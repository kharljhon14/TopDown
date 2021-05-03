using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ShakeFeedback : Feedback
    {
        [SerializeField] private GameObject objectToShake;
        [SerializeField] private float shakeDuration = .2f;
        [SerializeField] private float shakeStrength = 1f;
        [SerializeField] private float shakeRandomness = 90f;
        [SerializeField] private int vibrato = 10;
        [SerializeField] private bool snapping = false;
        [SerializeField] private bool fadeOut = true;

        public override void CompletePreviousFeedback()
        {
            objectToShake.transform.DOComplete();
        }

        public override void CreateFeedback()
        {
            CompletePreviousFeedback();
            objectToShake.transform.DOShakePosition(shakeDuration, shakeStrength, vibrato, shakeRandomness, snapping, fadeOut);
        }
    }
}
