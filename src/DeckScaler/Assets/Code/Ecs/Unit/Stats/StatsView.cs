using Entitas.Generic;
using SmartIdTable;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class StatsView : BaseListener<Game, Component.Stats>
    {
        [SerializeField] private SerializedDictionary<Suit, TMP_Text> _suits;

        public override void OnValueChanged(Entity<Game> entity, Component.Stats component)
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