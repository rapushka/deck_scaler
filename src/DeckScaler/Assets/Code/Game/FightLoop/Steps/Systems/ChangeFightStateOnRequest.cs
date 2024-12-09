using DeckScaler.Component;
using DeckScaler.Scopes;
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

        private readonly IGroup<Entity<Game>> _blockers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<BlockFightStepChange>().Build()
            );

        private static ProgressData Progress => ServiceLocator.Get<IProgress>().CurrentRun;

        private static IDebug Debug => ServiceLocator.Get<IDebug>();

        public void Execute()
        {
            if (_blockers.Any())
                return;

            foreach (var request in _requests)
            {
                var oldStep = Progress.CurrentFightStep;
                var newStep = request.Get<RequestChangeFightStep>().Value;

                Debug.Log(nameof(FightStep), $"Change Fight Step: {oldStep} -> {newStep}");

                Progress.CurrentFightStep = newStep;

                CreateEntity.OneFrame()
                            .Is<PlayerPrepareStepStarted>(newStep is FightStep.PlayerPrepare)
                            .Is<PlayerAttackStepStarted>(newStep is FightStep.PlayerAttack)
                            .Is<EnemyAttackStepStarted>(newStep is FightStep.EnemyAttack)
                    ;

                request.Add<Destroy>();
            }
        }
    }
}