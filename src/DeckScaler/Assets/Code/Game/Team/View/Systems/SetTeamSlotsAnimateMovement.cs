using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SetTeamSlotsAnimateMovement : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamSlot>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var slot in _slots)
                slot.Is<AnimateMovement>(true);
        }
    }
}