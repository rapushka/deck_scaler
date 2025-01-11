using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MarkDeadUnitsWithZeroHp : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<Health>()
                    .Without<Dead>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new();

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                if (unit.Get<Health>().Value <= 0)
                {
                    unit
                        .Is<Dead>(true)
                        .Is<JustDied>(true)
                        ;
                }
            }
        }
    }
}