using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private ProgressData   Progress => Services.Get<IProgress>().CurrentRun;
        private TeamSlotConfig Config   => Services.Get<IConfigs>().TeamSlot;

        private IFactories Factory => Services.Get<IFactories>();

        public Entity<Game> Create()
        {
            Progress.AddTeammate();

            return Factory.CreateEntityBehaviour(Config.ViewPrefab)
                          .Add<Name, string>("slot")
                          .Add<TeamSlot, int>(Progress.TeamSize);
        }
    }
}