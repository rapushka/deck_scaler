using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class PutNewUnitInFirstAvailableSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Queued>()
                .And<UnitID>()
        );
        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
        );

        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var isTeammate = unit.Is<Teammate>();

                foreach (var slot in _slots)
                {
                    if (isTeammate && !slot.Has<HeldTeammate>())
                    {
                        unit.SetupToSlotAsTeammate(slot)
                            .Is<Queued>(false)
                            ;

                        break;
                    }

                    if (!isTeammate && !slot.Has<HeldEnemy>())
                    {
                        unit.SetupToSlotAsEnemy(slot)
                            .Is<Queued>(false)
                            ;

                        break;
                    }
                }

                if (unit.Is<Queued>())
                    unit.Is<NeedsNewSlot>(true);
            }
        }
    }
}