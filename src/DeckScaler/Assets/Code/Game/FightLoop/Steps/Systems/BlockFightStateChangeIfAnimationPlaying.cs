using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class BlockFightStateChangeIfAnimationPlaying : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _animations = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PlayingAnimation>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _animations)
            {
                CreateEntity.OneFrame()
                            .Add<Name, string>("blocked by Playing Animation")
                            .Add<BlockFightStepChange>()
                    ;
            }
        }
    }
}