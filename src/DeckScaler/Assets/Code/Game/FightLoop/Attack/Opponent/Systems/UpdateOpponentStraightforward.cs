using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class UpdateOpponentStraightforward : IExecuteSystem
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
                    .With<UnitID>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Without<Opponent>()
            );
        private readonly List<Entity<Game>> _buffer = new(128);

        private static ScopeContext<Game> Context => Contexts.Instance.Get<Game>();

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var slotIndex = unit.Get<SlotIndex, int>();
                var side = unit.Get<OnSide, Side>();

                if (!Context.TryGetUnitFromSlot(slotIndex, side.Flip(), out var opponent))
                    continue;

                if (!opponent.Is<Dead>())
                    unit.SetByID<Opponent>(opponent);
            }
        }
    }
}