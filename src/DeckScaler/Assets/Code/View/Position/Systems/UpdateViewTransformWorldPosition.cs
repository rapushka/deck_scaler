using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class UpdateViewTransformWorldPosition : ReactiveSystem<Entity<Game>>
    {
        public UpdateViewTransformWorldPosition() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<WorldPosition>().Added());

        protected override bool Filter(Entity<Game> entity) => entity.Has<WorldPosition>();

        protected override void Execute(List<Entity<Game>> entities)
        {
            foreach (var entity in entities)
            {
                var z = entity.GetOrDefault<ZOrder, float>();
                var position = entity.Get<WorldPosition>().Value.Extend(z);

                entity.Get<ViewTransform>().Value.position = position;
            }
        }
    }
}