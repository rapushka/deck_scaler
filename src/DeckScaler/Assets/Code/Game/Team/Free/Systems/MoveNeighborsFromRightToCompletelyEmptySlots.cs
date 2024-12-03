using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class MoveNeighborsFromRightToCompletelyEmptySlots : IExecuteSystem
    {
        private List<Entity<Game>> _buffer;

        private static TeamSlotsUtil TeamSlotsUtil => Services.Get<IUtils>().TeamSlotsUtil;

        public void Execute()
        {
            var movedSlots = 0;

            foreach (var (slot, _) in TeamSlotsUtil.GetTeamSlotsInOrder())
            {
                if (slot.Is<FreedBoth>())
                {
                    movedSlots++;
                    continue;
                }

                slot.Increment<TeamSlot>(-movedSlots);
            }

            // foreach (var slot in _slots.GetEntities(_buffer))
            // {
            //     var side = slot.Get<FreedSubSlot, Side>();
            //
            //     var slotIndex = slot.Get<TeamSlot, int>();
            //     if (Index.TryGetEntity(slotIndex + 1, out var rightSlot))
            //     {
            //         if (rightSlot.TryGetUnitFromSide(side, out var unitID))
            //         {
            //             var rightUnit = unitID.GetEntity();
            //         }
            //     }
            // }
        }
    }
}