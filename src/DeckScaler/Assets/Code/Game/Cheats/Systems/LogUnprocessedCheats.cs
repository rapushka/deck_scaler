using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class LogUnprocessedCheats : IExecuteSystem
    {
        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<Cheat>()
                    .Without<Processed>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var entity in _cheats)
            {
                var cheat = entity.Get<Cheat>().Value;
                Services.Get<IDebug>().LogError(nameof(Cheats), $"Cheat \"{cheat}\" doesn't exist!");
            }
        }
    }
}