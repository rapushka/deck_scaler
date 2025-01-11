using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class ResetOpponent : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecalculateOpponents>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Opponent>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(128);

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _units.GetEntities(_buffer))
                unit.Remove<Opponent>();
        }
    }
}