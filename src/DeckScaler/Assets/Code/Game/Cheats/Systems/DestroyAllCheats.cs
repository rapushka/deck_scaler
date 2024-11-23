using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class DestroyAllCheats : ICleanupSystem
    {
        private readonly IGroup<Entity<Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Cheats>
                    .With<Cheat>()
                    .Build()
            );
        private readonly List<Entity<Cheats>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
                entity.Destroy();
        }
    }
}