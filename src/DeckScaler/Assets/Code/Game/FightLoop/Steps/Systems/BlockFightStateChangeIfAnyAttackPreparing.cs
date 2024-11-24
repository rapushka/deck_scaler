using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class BlockFightStateChangeIfAnyAttackPreparing : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PrepareAttack>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _attackers)
            {
                CreateEntity.OneFrame()
                            .Add<Name, string>("blocked by Prepare Attack")
                            .Add<BlockFightStepChange>()
                    ;
            }
        }
    }
}