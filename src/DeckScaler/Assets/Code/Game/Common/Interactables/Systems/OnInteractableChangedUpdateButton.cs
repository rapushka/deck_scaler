using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnInteractableChangedUpdateButton : ReactiveSystem<Entity<Game>>
    {
        public OnInteractableChangedUpdateButton() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<Interactable>().AddedOrRemoved());

        protected override bool Filter(Entity<Game> e) => e.Is<EnableOnlyInPlayerPrepare>() && e.Has<UiButton>();

        protected override void Execute(List<Entity<Game>> entities)
        {
            foreach (var entity in entities)
            {
                var button = entity.Get<UiButton>().Value;
                button.interactable = entity.Is<Interactable>();
            }
        }
    }
}