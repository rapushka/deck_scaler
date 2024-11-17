using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Game>;

namespace DeckScaler.Systems
{
    public class MarkLoaded : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(Get<Loading>());
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Is<Loading>(false);
        }
    }
}