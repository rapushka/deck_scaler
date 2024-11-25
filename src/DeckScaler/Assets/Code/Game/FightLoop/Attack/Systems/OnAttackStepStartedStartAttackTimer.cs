using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnAttackStepStartedStartAttackTimer<TEventComponent, THeldComponent> : IExecuteSystem
        where TEventComponent : FlagComponent, IInScope<Game>, new()
        where THeldComponent : ValueComponent<EntityID>, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _event = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TEventComponent>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
                .Build()
        );

        private static float DelayBetweenAttacks => Services.Get<IConfigs>().Units.DelayBetweenAttacks;

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var (slot, index) in _slots.GetTeamSlotsInOrder())
            {
                if (slot.TryGet<THeldComponent, EntityID>(out var unitID))
                {
                    var unit = unitID.GetEntity();
                    unit.Add<TimerBeforeAttack, Timer>(new Timer(index * DelayBetweenAttacks));
                }
            }
        }
    }
}