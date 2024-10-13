using DeckScaler.Utils;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class StatsView : BaseListener<Scope, Component.Stats>
    {
        [SerializeField] private SerializableDictionary<Suit, TMP_Text> _suits;

        public override void OnValueChanged(Entity<Scope> entity, Component.Stats component)
        {
#if DEBUG
            Debug.Assert(_suits.Count == 4);
            Debug.Assert(component.Value.Count == 4);
#endif

            foreach (var (suit, stat) in component.Value)
                _suits[suit].text = stat.ToString();
        }
    }
}