using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class FeedbackPlayer : MonoBehaviour
    {
        [SerializeField] private List<Feedback> feedbackToPlay = null;

        public void PlayFeedback()
        {
            FinishFeedback();
            foreach (Feedback feedback in feedbackToPlay)
            {
                feedback.CreateFeedback();
            }
        }

        private void FinishFeedback()
        {
            foreach (Feedback feedback in feedbackToPlay)
            {
                feedback.CompletePreviousFeedback();
            }
        }
    }
}
