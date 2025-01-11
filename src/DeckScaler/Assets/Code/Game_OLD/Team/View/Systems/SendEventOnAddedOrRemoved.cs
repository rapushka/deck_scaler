using System.Collections.Generic;
using System.Linq;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SendEventOnAddedOrRemoved<TTarget, TEVent> : ReactiveSystem<Entity<Game>>
        where TTarget : IComponent, IInScope<Game>, new()
        where TEVent : IComponent, IInScope<Game>, new()
    {
        public SendEventOnAddedOrRemoved() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<TTarget>().AddedOrRemoved());

        protected override bool Filter(Entity<Game> entity) => true;

        protected override void Execute(List<Entity<Game>> teamSlots)
        {
            if (teamSlots.Any())
                CreateEntity.OneFrame().Add<TEVent>();
        }
    }
}