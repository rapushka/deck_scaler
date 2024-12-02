using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private ProgressData       Progress   => Services.Get<IProgress>().CurrentRun;
        private TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        private IFactories Factory => Services.Get<IFactories>();

        public Entity<Game> Create()
        {
            var entity = Factory.CreateEntityBehaviour(ViewConfig.ViewPrefab)
                .Add<TeamSlot, int>(Progress.TeamSlotsCounter);

            Progress.IncrementTeamSlotCount();

            return entity;
        }
    }
}