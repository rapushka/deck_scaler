using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnAttackStepStartedStartAttackTimer<TEventComponent, TSideComponent> : IExecuteSystem
        where TEventComponent : FlagComponent, IInScope<Game>, new()
        where TSideComponent : FlagComponent, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _event = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TEventComponent>()
                .Build()
        );
        private readonly IGroup<Entity<Game>> _units = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<UnitID>()
                .And<TSideComponent>()
                .Build()
        );

        private static float DelayBetweenAttacks => Services.Get<IConfigs>().Units.DelayBetweenAttacks;

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var unit in _units)
            {
                var index = unit.Get<SlotIndex, int>();
                unit.Add<TimerBeforeAttack, Timer>(new(index * DelayBetweenAttacks));
            }
        }
    }
}