using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnTimerBeforeAttackElapsedThenAttackOpponent : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TimerBeforeAttack>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Execute()
        {
            foreach (var attacker in _attackers.GetEntities(_buffer))
            {
                if (!attacker.Get<TimerBeforeAttack, Timer>().IsElapsed)
                    continue;

                if (attacker.TryGetOpponent(out var opponentID))
                    attacker.Add<PrepareAttack, EntityID>(opponentID);

                attacker.Remove<TimerBeforeAttack>();
            }
        }
    }
}