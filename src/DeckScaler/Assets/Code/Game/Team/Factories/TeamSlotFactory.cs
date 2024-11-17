using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private static ProgressData Progress => Services.Get<Progress>().CurrentRun;

        public Entity<Game> Create()
        {
            Progress.AddTeammate();

            return CreateEntity.New()
                               .Add<Name, string>("slot")
                               .Add<TeamSlot, int>(Progress.TeamSize)
                ;
        }
    }
}