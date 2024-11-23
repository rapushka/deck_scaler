using System;
using DeckScaler.Utils;
using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private AnimationArgs _attackAnimationArgs;
        [SerializeField] private AnimationArgs _flinchAnimationArgs;

        private float _initialScale;
        private Tween _tween;

        private void Awake()
        {
            _initialScale = transform.localScale.x;
        }

        public void PlayAttackAnimation(Vector2 targetWorldPosition)
        {
            var punchDirection = targetWorldPosition - transform.position.Flat();
            var args = _attackAnimationArgs;

            _tween?.Kill();
            _tween = DOTween.Sequence()
                            // startup
                            .Append(transform.DOScale(_initialScale * args.Scale, args.Duration))
                            .Append(transform.DOPunchPosition(punchDirection, args.Duration, args.Vibrato, args.Elasticity))

                            // active
                            .AppendCallback(() => { }) // TODO: callback

                            // recovery
                            .Append(transform.DOScale(_initialScale, args.ReturnDuration))
                ;
        }

        public void PlayFlinchAnimation()
        {
            var args = _flinchAnimationArgs;

            _tween?.Kill();
            _tween = DOTween.Sequence()
                            .Append(transform.DOPunchPosition(args.PunchPosition, args.Duration, args.Vibrato, args.Elasticity))
                            .Join(transform.DOScale(_initialScale * args.Scale, args.Duration))

                            // recovery
                            .Append(transform.DOScale(_initialScale, args.ReturnDuration))
                ;
        }

        [Serializable]
        private class AnimationArgs
        {
            [field: SerializeField] public float   Duration      { get; private set; } = 0.3f;
            [field: SerializeField] public float   Scale         { get; private set; } = 1f;
            [field: SerializeField] public Vector2 PunchPosition { get; private set; }
            [field: SerializeField] public int     Vibrato       { get; private set; } = 10;
            [field: SerializeField] public float   Elasticity    { get; private set; } = 1f;

            [field: SerializeField] public float ReturnDuration { get; private set; } = 0.3f;
        }
    }
}