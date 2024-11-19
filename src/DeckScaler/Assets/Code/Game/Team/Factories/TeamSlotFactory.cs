using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private ProgressData   Progress => Services.Get<IProgress>().CurrentRun;
        private TeamSlotConfig Config   => Services.Get<IConfigs>().TeamSlot;

        private EntityBehaviourFactory ViewFactory => Services.Get<IFactories>().EntityBehaviour;

        public Entity<Game> Create()
        {
            Progress.AddTeammate();

            return ViewFactory.Create(Config.ViewPrefab).Entity
                              .Add<Name, string>("slot")
                              .Add<TeamSlot, int>(Progress.TeamSize);
        }
    }
}