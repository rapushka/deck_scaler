using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class AfterFillGapsDelayElapsedDestroyRequest : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _fillRequests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<FillGapRequest>()
                    .And<FillGapAfter>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var request in _fillRequests)
            {
                if (!request.Get<FillGapAfter, Timer>().IsElapsed)
                    continue;

                request.Add<Destroy>();
            }
        }
    }
}