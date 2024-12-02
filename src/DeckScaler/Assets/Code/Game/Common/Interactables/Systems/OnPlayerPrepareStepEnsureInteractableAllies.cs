using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnPlayerPrepareStepEnsureInteractableAllies : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _teammates
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Teammate>()
                    .And<EnableOnlyInPlayerPrepare>()
                    .Without<Interactable>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Execute()
        {
            if (Progress.CurrentFightStep is not FightStep.PlayerPrepare)
                return;

            foreach (var teammate in _teammates.GetEntities(_buffer))
                teammate.Is<Interactable>(true);
        }
    }
}