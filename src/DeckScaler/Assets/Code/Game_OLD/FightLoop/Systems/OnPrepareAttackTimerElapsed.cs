using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnPrepareAttackTimerElapsed : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PrepareAttackTimer>()
                .And<PrepareAttack>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var attacker in _attackers.GetEntities(_buffer))
            {
                if (attacker.Get<PrepareAttackTimer, Timer>().IsElapsed)
                    attacker.Remove<PrepareAttack>();
            }
        }
    }
}