using System;
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Systems;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class FightLoopFeature : Feature
    {
        public FightLoopFeature()
            : base(nameof(FightLoopFeature))
        {
            Add(new OnEndTurnAllTeammatesAttackOpponents());
            Add(new Test_OnAttackAllTeammatesWithoutOpponentsAttackRandomEnemy());

            Add(new EnemyAttackFeature());

            Add(new StartAttackTimer());
            Add(new SendDealDamageOnAttackPrepareTimerElapsed());

            Add(new CleanupElapsedPrepareAttackTimer());
        }
    }

    public class Test_OnAttackAllTeammatesWithoutOpponentsAttackRandomEnemy : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<EndTurn>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _teammates = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Teammate>()
                .And<BaseDamage>()
                .And<InSlot>()
                .Without<PrepareAttack>()
                .Build()
        );
        private readonly IGroup<Entity<Game>> _enemies = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Enemy>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var teammate in _teammates.GetEntities(_buffer))
            {
                teammate.Add<PrepareAttack, EntityID>(GetFirstEnemy().ID());
            }
        }

        private Entity<Game> GetFirstEnemy()
        {
            foreach (var enemy in _enemies)
            {
                return enemy;
            }

            throw new InvalidOperationException("no enemies? :(");
        }
    }
}