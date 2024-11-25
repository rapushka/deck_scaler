using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class StartAttackTimer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PrepareAttack>()
                .Without<PrepareAttackTimer>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var attacker in _attackers.GetEntities(_buffer))
            {
                var duration = attacker.GetOrDefault<PrepareAttackAnimationDuration, float>();
                attacker.Add<PrepareAttackTimer, Timer>(new Timer(duration));
            }
        }
    }
}