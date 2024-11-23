using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private float _attackAnimationDuration = 0.5f;
        [SerializeField] private float _flinchAnimationDuration = 0.3f;

        public void PlayAttackAnimation()
        {
            transform.DOScale(Vector3.one * 1.2f, _attackAnimationDuration)
                     .OnComplete(() => transform.DOScale(Vector3.one, _attackAnimationDuration));

            transform.DOPunchPosition(new Vector3(0.2f, 0, 0), _attackAnimationDuration, 10, 1);
        }

        public void PlayFlinchAnimation()
        {
            transform.DOPunchPosition(new Vector3(-0.1f, 0, 0), _flinchAnimationDuration, 10, 1)
                     .OnComplete(() => transform.DOPunchPosition(new Vector3(0.1f, 0, 0), _flinchAnimationDuration, 10, 1));

            transform.DOScale(Vector3.one * 0.9f, _flinchAnimationDuration)
                     .OnComplete(() => transform.DOScale(Vector3.one, _flinchAnimationDuration));
        }
    }
}