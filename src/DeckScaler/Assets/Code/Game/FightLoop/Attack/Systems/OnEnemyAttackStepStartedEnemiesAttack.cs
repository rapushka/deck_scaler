using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnEnemyAttackStepStartedEnemiesAttack : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<EnemyAttackStepStarted>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _enemies = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Enemy>()
                .And<BaseDamage>()
                .And<InSlot>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var enemy in _enemies)
            {
                if (enemy.TryGetOpponent(out var teammateID))
                    enemy.Add<PrepareAttack, EntityID>(teammateID);
            }
        }
    }
}