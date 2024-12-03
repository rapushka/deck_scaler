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

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Execute()
        {
            var removedSlots = 0;

            foreach (var (slot, _) in TeamSlotsUtil.GetTeamSlotsInOrder())
            {
                if (slot.Is<FreedBoth>())
                {
                    Progress.DecrementTeamSlotCount();
                    removedSlots++;

                    // slot.Replace<TeamSlot, int>(-removedSlots); // TODO: this is a shitty one:(
                    slot.Remove<TeamSlot>();
                    continue;
                }

                slot.Increment<TeamSlot>(-removedSlots);
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