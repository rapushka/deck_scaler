using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
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

        private IFactories Factory => Services.Get<IFactories>();

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var slot = Factory.CreateTeamSlot();

                if (unit.Is<Teammate>())
                    unit.SetupTeammateToSlot(slot);
                else
                    unit.SetupEnemyToSlot(slot);

                unit.Is<NeedsNewSlot>(false);
                unit.Is<Queued>(false);
            }
        }
    }
}