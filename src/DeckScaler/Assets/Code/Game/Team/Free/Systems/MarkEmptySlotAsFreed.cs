using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class MarkEmptySlotAsFreed : ReactiveSystem<Entity<Game>>
    {
        public MarkEmptySlotAsFreed() : base(Contexts.Instance.Get<Game>()) { }

        private static IDebug Debug => Services.Get<IDebug>();

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<JustDied>().Added());

        protected override bool Filter(Entity<Game> entity) => entity.Has<UnitID>() && entity.Is<JustDied>();

        protected override void Execute(List<Entity<Game>> units)
        {
            foreach (var unit in units)
            {
                var side = unit.Get<OnSide>().Value;
                var slot = unit.Get<InSlot>().Value.GetEntity();

                if (slot.TryGet<FreedSubSlot, Side>(out var alreadyFreedSide))
                {
                    Debug.Assert(alreadyFreedSide != side);

                    slot.Is<FreedBoth>(true);
                    continue;
                }

                slot.Add<FreedSubSlot, Side>(side);
            }
        }
    }
}