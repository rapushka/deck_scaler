using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class ReactOnRequestEndPlayerPrepareStep : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<EndPlayerPrepareStep>().Build()
            );

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Execute()
        {
            if (!_requests.Any())
                return;

            if (Progress.CurrentFightStep is not FightStep.PlayerPrepare)
                return;

            CreateEntity.Empty()
                        .Add<RequestChangeFightStep, FightStep>(FightStep.PlayerAttack)
                ;
        }
    }
}