using DeckScaler.Component;
using DeckScaler.Utils;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private static ProgressData Progress => Services.Get<Progress>().CurrentRun;

        public Entity<Model> Create()
        {
            Progress.AddTeammate();

            return CreateEntity.New<Model>()
                               .Add<Name, string>("slot")
                               .Add<TeamSlot, int>(Progress.TeamSize)
                ;
        }
    }
}