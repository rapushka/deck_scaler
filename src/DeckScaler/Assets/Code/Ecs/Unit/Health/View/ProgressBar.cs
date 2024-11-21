using UnityEngine;

namespace DeckScaler
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
        [SerializeField] private SpriteRenderer _fillSpriteRenderer;

        public float NormalizedValue
        {
            set
            {
                value = Mathf.Clamp01(value);

                var bgTransform = _backgroundSpriteRenderer.transform;
                var fillTransform = _fillSpriteRenderer.transform;

                var newScale = bgTransform.localScale;
                newScale.x = bgTransform.localScale.x * value;

                fillTransform.localScale = newScale;
            }
        }
    }
}