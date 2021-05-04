using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class DissolveFeedback : Feedback
    {
        [SerializeField] private SpriteRenderer sr = null;
        [SerializeField] private float duration = 0.5f;
        [field: SerializeField] public UnityEvent DeathCallback { get; set; }

        public override void CompletePreviousFeedback()
        {
            sr.DOComplete();
            sr.material.DOComplete();
        }

        public override void CreateFeedback()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(sr.material.DOFloat(0, "_Dissolve", duration));

            if(DeathCallback != null)
                sequence.AppendCallback(() => DeathCallback.Invoke());
        }
    }
}