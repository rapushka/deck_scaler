using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class BlockFightStateChangeIfWaitingForAttackAnimations : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _animations = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<WaitingForAttackAnimations>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _animations)
            {
                CreateEntity.OneFrame()
                            .Add<BlockFightStepChange>()
                    ;
            }
        }
    }
}