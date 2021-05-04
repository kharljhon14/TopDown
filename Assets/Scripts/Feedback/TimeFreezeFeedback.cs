using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class TimeFreezeFeedback : Feedback
    {
        [SerializeField] private float freezeTimeDelay = 0.01f;
        [SerializeField] private float unFreezeTimeDelay = 0.02f;
        [SerializeField] [Range(0, 1)] private float timeFreezeValue = 0.2f;

        public override void CompletePreviousFeedback()
        {
            if(TimeManager.instance != null)
                TimeManager.instance.ResetTimeScale();
        }

        public override void CreateFeedback()
        {
            TimeManager.instance.ModifyTimeScale(timeFreezeValue, freezeTimeDelay, () => TimeManager.instance.ModifyTimeScale(1, unFreezeTimeDelay));
        }
    }
}
