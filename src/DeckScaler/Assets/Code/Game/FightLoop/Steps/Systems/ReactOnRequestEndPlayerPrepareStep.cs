using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class ReactOnRequestEndPlayerPrepareStep : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<ExitPlayerPrepareStep>().Build()
            );

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var _ in _requests)
            {
                if (Progress.CurrentFightStep is FightStep.PlayerPrepare)
                {
                    CreateEntity.Empty()
                        .Add<RequestChangeFightStep, FightStep>(FightStep.PlayerAttack)
                        ;
                }
            }
        }
    }
}