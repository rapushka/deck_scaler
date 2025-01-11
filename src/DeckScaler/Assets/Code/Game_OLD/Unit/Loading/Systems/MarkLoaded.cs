using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Scopes.Game>;

namespace DeckScaler
{
    public class MarkLoaded : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(Get<Loading>());
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.Is<Loading>(false);

                if (entity.TryGet<View, EntityBehaviour<Game>>(out var view))
                    view.SetActive(true);
            }
        }
    }
}