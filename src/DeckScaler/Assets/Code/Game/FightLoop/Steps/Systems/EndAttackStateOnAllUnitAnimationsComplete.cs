using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class EndAttackStateOnAllUnitAnimationsComplete : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<AllAnimationsCompleted>()
                    .Build()
            );

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var _ in _events)
            {
                if (TryChangeState(from: FightStep.PlayerAttack, to: FightStep.EnemyAttack))
                    return;

                if (TryChangeState(from: FightStep.EnemyAttack, to: FightStep.PlayerPrepare))
                    return;

                Services.Get<IDebug>().LogError(nameof(FightStep), "Unknown Fight Step Transition");
            }
        }

        private static bool TryChangeState(FightStep from, FightStep to)
        {
            var isFromCurrent = Progress.CurrentFightStep == from;

            if (isFromCurrent)
            {
                CreateEntity.Empty()
                            .Add<RequestChangeFightStep, FightStep>(to)
                    ;
            }

            return isFromCurrent;
        }
    }
}