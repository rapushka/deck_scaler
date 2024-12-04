using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnPlayerPrepareStepStartFillGapsTimer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<PlayerPrepareStepStarted>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _fillRequests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<FillGapRequest>()
                    .Without<FillGapAfter>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        private static TeamSlotViewConfig Config => Services.Get<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var request in _fillRequests.GetEntities(_buffer))
            {
                request.Add<FillGapAfter, Timer>(new(Config.DelayBeforeFillingGaps));
            }
        }
    }
}