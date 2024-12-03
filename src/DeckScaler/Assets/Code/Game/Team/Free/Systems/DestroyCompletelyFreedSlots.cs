using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class DestroyCompletelyFreedSlots : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<FreedBoth>()
                    .And<TeamSlot>()
                    .Without<Destroy>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var e in _slots.GetEntities(_buffer))
                e.Is<Destroy>(true);
        }
    }
}