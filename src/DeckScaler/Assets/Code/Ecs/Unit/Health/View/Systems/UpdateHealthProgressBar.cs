using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class UpdateHealthProgressBar : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _bars
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Health>()
                    .And<MaxHealth>()
                    .And<HealthProgressBar>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var bar in _bars)
            {
                var currentHP = bar.Get<Health>().Value;
                var maxHP = bar.Get<MaxHealth>().Value;

                var progressBar = bar.Get<HealthProgressBar>().Value;
                progressBar.NormalizedValue = (float)currentHP / maxHP;
            }
        }
    }
}