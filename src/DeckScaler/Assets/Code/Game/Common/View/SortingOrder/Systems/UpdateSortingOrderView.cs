using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class UpdateSortingOrderView : ReactiveSystem<Entity<Game>>
    {
        public UpdateSortingOrderView() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<SpriteSortOrder>().Added());

        protected override bool Filter(Entity<Game> entity)
            => entity.Has<SpriteSortOrder>() && entity.Has<SortingGroupView>();

        protected override void Execute(List<Entity<Game>> entities)
        {
            foreach (var e in entities)
            {
                var sortingGroup = e.Get<SortingGroupView>().Value;
                var order = e.Get<SpriteSortOrder>().Value;

                sortingGroup.sortingOrder = order;
            }
        }
    }
}