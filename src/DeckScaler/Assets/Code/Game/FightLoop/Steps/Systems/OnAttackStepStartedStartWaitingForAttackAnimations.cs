using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnAttackStepStartedStartWaitingForAttackAnimations : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .WithOr<PlayerAttackStepStarted>()
                .Or<EnemyAttackStepStarted>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _events)
            {
                CreateEntity.Empty()
                            .Add<WaitingForAttackAnimations>();
            }
        }
    }
}