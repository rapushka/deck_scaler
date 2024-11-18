using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class PutNewEnemyInFirstAvailableSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _enemies = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Queued>()
                .And<UnitID>()
                .And<Enemy>()
        );
        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
        );

        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var enemy in _enemies.GetEntities(_buffer))
            {
                foreach (var slot in _slots)
                {
                    if (slot.Has<HeldEnemy>())
                        continue;

                    enemy.SetupToSlotAsEnemy(slot)
                         .Is<Queued>(false)
                        ;

                    break;
                }

                if (enemy.Is<Queued>())
                    enemy.Is<NeedsNewSlot>(true);
            }
        }
    }
}