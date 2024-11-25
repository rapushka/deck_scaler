using System;
using DeckScaler.Utils;
using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private AttackAnimationArgs _attackAnimationArgs;
        [SerializeField] private FlinchAnimationArgs _flinchAnimationArgs;

        private TransformData _initTransform;

        private Tween _tween;

        public float InitialScale => _initTransform.LocalScale.x;

        public Tween PlayAttackAnimation(Vector2 targetWorldPosition)
        {
            _tween?.Kill();
            _initTransform = transform.Save();

            var punchDirection = targetWorldPosition - transform.position.Flat();

            var args = _attackAnimationArgs;
            punchDirection *= args.PunchDistance;
            transform.SetGlobalPosition(z: args.ZOffset);

            _tween = DOTween.Sequence()
                            // prepare
                            .Append(transform.DOScale(InitialScale * args.Scale, args.Duration))
                            .Append(transform.DOPunchPosition(punchDirection, args.Duration, vibrato: 0))

                            // recovery
                            .Append(transform.DOScale(InitialScale, args.ReturnDuration))
                            .OnKill(ResetTransform)
                ;

            return _tween;
        }

        public Tween PlayFlinchAnimation()
        {
            _tween?.Kill();
            _initTransform = transform.Save();

            var args = _flinchAnimationArgs;

            _tween = DOTween.Sequence()
                            .Append(transform.DOPunchPosition(args.PunchPosition, args.Duration, args.Vibrato, args.Elasticity))
                            .Join(transform.DOScale(InitialScale * args.Scale, args.Duration))

                            // recovery
                            .Append(transform.DOScale(InitialScale, args.ReturnDuration))
                            .OnKill(ResetTransform)
                ;

            return _tween;
        }

        private void ResetTransform() => transform.Load(_initTransform);

        [Serializable]
        private class AnimationArgs
        {
            [field: SerializeField] public float Duration { get; private set; } = 0.3f;
            [field: SerializeField] public float Scale    { get; private set; } = 1f;

            [field: SerializeField] public float ReturnDuration { get; private set; } = 0.3f;
        }

        [Serializable]
        private class AttackAnimationArgs : AnimationArgs
        {
            [field: SerializeField] public float PunchDistance { get; private set; } = 1f;
            [field: SerializeField] public float ZOffset       { get; private set; } = -10f;
        }

        [Serializable]
        private class FlinchAnimationArgs : AnimationArgs
        {
            [field: SerializeField] public Vector2 PunchPosition { get; private set; }

            [field: SerializeField] public int   Vibrato    { get; private set; } = 10;
            [field: SerializeField] public float Elasticity { get; private set; } = 1f;
        }
    }
}