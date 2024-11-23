using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class LogUnprocessedCheats : IExecuteSystem
    {
        private readonly IGroup<Entity<Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Cheats>
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