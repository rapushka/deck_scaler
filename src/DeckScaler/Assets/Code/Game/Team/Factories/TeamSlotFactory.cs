using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private ProgressData   Progress => Services.Get<IProgress>().CurrentRun;
        private TeamSlotViewConfig ViewConfig   => Services.Get<IConfigs>().TeamSlotView;

        private IFactories Factory => Services.Get<IFactories>();

        public Entity<Game> Create()
        {
            Progress.AddTeammate();

            return Factory.CreateEntityBehaviour(ViewConfig.ViewPrefab)
                          .Add<Name, string>("slot")
                          .Add<TeamSlot, int>(Progress.TeamSize);
        }
    }
}