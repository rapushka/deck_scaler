using System;
using MoreMountains.Feedbacks;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    public class FloatingNumberView : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<Type, Data> _playersByType;

        public void Play(int number, Type type)
        {
            var data = _playersByType[type];
            data.FloatingText.Value = data.Template.Format(number.Abs());

            data.Player.PlayFeedbacks(transform.localPosition, number);
        }

        [Serializable]
        public enum Type
        {
            Unknown = 0,
            Damage = 1,
            Heal = 2,
            StealMoneyFromPlayer = 3,
            StealMoneyFromEnemy = 4,
        }

        [Serializable]
        private class Data
        {
            [field: SerializeField] public MMF_Player Player   { get; private set; }
            [field: SerializeField] public string     Template { get; private set; } = "{0}";

            private MMF_FloatingText _floatingText;

            public MMF_FloatingText FloatingText
                => _floatingText ??= Player.GetFeedbackOfType<MMF_FloatingText>();
        }
    }
}