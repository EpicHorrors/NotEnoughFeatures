using System.Collections;
using MiraAPI.Utilities;
using UnityEngine;
using System;

namespace NotEnoughFeatures.Patches
{
    public class Coroutine
    {
        public IEnumerator CleanBodyCoroutine(Byte target)
        {
            var body = Helpers.GetBodyById(target);
            SpriteRenderer rend = body.bodyRenderers[0];
            Color initialColor = rend.color;
            float duration = 2f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                rend.color = Color.Lerp(initialColor, Color.clear, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            rend.color = Color.clear;
            UnityEngine.Object.Destroy(body.gameObject);
        }
    }
}