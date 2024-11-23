using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class ChangeFightStateOnRequest : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<RequestChangeFightStep>().Build()
            );

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var request in _requests)
            {
                var newStep = request.Get<RequestChangeFightStep>().Value;
                Progress.CurrentFightStep = newStep;

                CreateEntity.OneFrame()
                            .Is<PlayerPrepareStepStarted>(newStep is FightStep.PlayerPrepare)
                            .Is<PlayerAttackStepStarted>(newStep is FightStep.PlayerAttack)
                            .Is<EnemyAttackStepStarted>(newStep is FightStep.EnemyAttack)
                    ;
            }
        }
    }
}