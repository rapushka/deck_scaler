using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnInteractableChangedUpdateCollider : ReactiveSystem<Entity<Game>>
    {
        public OnInteractableChangedUpdateCollider() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<Interactable>().AddedOrRemoved());

        protected override bool Filter(Entity<Game> e) => e.Is<EnableOnlyInPlayerPrepare>() && e.Has<ViewCollider>();

        protected override void Execute(List<Entity<Game>> entities)
        {
            foreach (var entity in entities)
            {
                var collider = entity.Get<ViewCollider>().Value;
                collider.enabled = entity.Is<Interactable>();
            }
        }
    }
}