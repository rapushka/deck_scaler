using UnityEngine;

namespace DeckScaler
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Transform _background;
        [SerializeField] private Transform _fill;

        public float NormalizedValue
        {
            set
            {
                value = Mathf.Clamp01(value);

                var bgScale = _background.localScale;
                _fill.localScale = _fill.localScale.With(x: bgScale.x * value);
            }
        }
    }
}