using System.Collections.Generic;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class CleanupElapsedTimers<TTimer> : ICleanupSystem
        where TTimer : ValueComponent<Timer>, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _timers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TTimer>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _timers.GetEntities(_buffer))
            {
                if (entity.Get<TTimer, Timer>().IsElapsed)
                    entity.Remove<TTimer>();
            }
        }
    }
}