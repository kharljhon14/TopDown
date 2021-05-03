using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class FlashFeedback : Feedback
    {
        [SerializeField] private SpriteRenderer sr = null;
        [SerializeField] private float flashTime = .1f;
        [SerializeField] private Material flashMaterial = null;

        private Shader orignialMaterialShader;

        private void Start()
        {
            orignialMaterialShader = sr.material.shader;
        }

        public override void CompletePreviousFeedback()
        {
            StopAllCoroutines();
            sr.material.shader = orignialMaterialShader;
        }

        public override void CreateFeedback()
        {
            if (!sr.material.HasProperty("_MakeSolidColor"))
                sr.material.shader = flashMaterial.shader;

            sr.material.SetInt("_MakeSolidColor", 1);
            StartCoroutine(WaitBeforeChangingBackCoroutine());
        }

        private IEnumerator WaitBeforeChangingBackCoroutine()
        {
            yield return new WaitForSeconds(flashTime);

            if (sr.material.HasProperty("_MakeSolidColor"))
                sr.material.SetInt("_MakeSolidColor", 0);

            else
                sr.material.shader = orignialMaterialShader;
        }
    }
}