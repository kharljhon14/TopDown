using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            else if (instance != this)
                Destroy(this);
        }

        public void ResetTimeScale()
        {
            StopAllCoroutines();
            Time.timeScale = 1;
        }

        public void ModifyTimeScale(float endTimeValue, float timeToWait, Action onCompleteCallback = null)
        {
            StartCoroutine(TimeScaleCoroutine(endTimeValue, timeToWait, onCompleteCallback));
        }

        private IEnumerator TimeScaleCoroutine(float endTimeValue, float timeToWait, Action onCompleteCallback)
        {
            yield return new WaitForSecondsRealtime(timeToWait);
            Time.timeScale = endTimeValue;
            onCompleteCallback?.Invoke();
        }
    }
}