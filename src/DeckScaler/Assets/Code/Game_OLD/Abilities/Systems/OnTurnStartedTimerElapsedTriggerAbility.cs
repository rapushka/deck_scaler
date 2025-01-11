using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnTurnStartedTimerElapsedTriggerAbility : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SendTurnStartedAfter>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                if (unit.IsElapsed<SendTurnStartedAfter>())
                {
                    unit
                        .Remove<SendTurnStartedAfter>()
                        .Add<TriggerOnTurnStartedAbility>()
                        ;
                }
            }
        }
    }
}