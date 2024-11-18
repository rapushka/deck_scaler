using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class PutNewTeammateInFirstAvailableSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _teammates = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Queued>()
                .And<UnitID>()
                .And<Teammate>()
        );
        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
        );

        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var teammate in _teammates.GetEntities(_buffer))
            {
                foreach (var slot in _slots)
                {
                    if (slot.Has<HeldTeammate>())
                        continue;

                    teammate.SetupToSlotAsTeammate(slot)
                            .Is<Queued>(false)
                        ;

                    break;
                }

                if (teammate.Is<Queued>())
                    teammate.Is<NeedsNewSlot>(true);
            }
        }
    }
}