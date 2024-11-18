using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SpawnTeamSlotForQueuedUnits : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<NeedsNewSlot>()
                .And<UnitID>()
        );

        private readonly List<Entity<Game>> _buffer = new(32);

        private TeamSlotFactory TeamSlotFactory => Services.Get<IFactories>().TeamSlot;

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var slot = TeamSlotFactory.Create();

                if (unit.Is<Teammate>())
                    unit.SetupToSlotAsTeammate(slot);
                else
                    unit.SetupToSlotAsEnemy(slot);

                unit.Is<NeedsNewSlot>(false);
                unit.Is<Queued>(false);
            }
        }
    }
}