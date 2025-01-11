using System.Collections.Generic;
using DeckScaler.Cheats.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class DestroyAllCheats : ICleanupSystem
    {
        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<Cheat>()
                    .Build()
            );
        private readonly List<Entity<Scopes.Cheats>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
                entity.Destroy();
        }
    }
}