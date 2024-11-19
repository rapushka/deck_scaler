using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private ProgressData   Progress => Services.Get<IProgress>().CurrentRun;
        private TeamSlotConfig Config   => Services.Get<IConfigs>().TeamSlot;

        public Entity<Game> Create()
        {
            Progress.AddTeammate();

            return CreateEntity.New()
                               .Add<Name, string>("slot")
                               .Add<TeamSlot, int>(Progress.TeamSize)
                               .Add<PrefabToLoad, EntityBehaviour>(Config.ViewPrefab)
                ;
        }
    }
}