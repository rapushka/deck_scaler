using System.Collections.Generic;
using System.Linq;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Scopes.Game>;

namespace DeckScaler.Systems
{
    public sealed class RequestArrangeTeamSlotsOnNewSlotCreated : ReactiveSystem<Entity<Game>>
    {
        public RequestArrangeTeamSlotsOnNewSlotCreated() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(Get<TeamSlot>().AddedOrRemoved());

        protected override bool Filter(Entity<Game> entity) => true;

        protected override void Execute(List<Entity<Game>> teamSlots)
        {
            if (teamSlots.Any())
                CreateEntity.OneFrame().Add<Component.ArrangeTeamSlots>();
        }
    }
}