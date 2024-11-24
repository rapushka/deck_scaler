using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnPlayerAttackStartedRequestEnemyAttack : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<PlayerAttackStepStarted>().Build()
            );

        public void Execute()
        {
            if (!_event.Any())
                return;

            CreateEntity.Empty()
                        .Add<RequestChangeFightStep, FightStep>(FightStep.EnemyAttack)
                ;
        }
    }
}