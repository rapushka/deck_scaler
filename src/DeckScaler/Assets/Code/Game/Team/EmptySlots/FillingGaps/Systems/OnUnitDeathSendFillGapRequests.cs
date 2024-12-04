using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnUnitDeathSendFillGapRequests : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _diedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<JustDied>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var diedUnit in _diedUnits)
            {
                var index = diedUnit.Get<SlotIndex, int>();
                var side = diedUnit.Get<OnSide, Side>();

                CreateEntity.Empty()
                    .Is<FillGapRequest>(true)
                    .Add<FreedSlotIndex, int>(index)
                    .Add<FreedSlotSide, Side>(side)
                    ;
            }
        }
    }
}