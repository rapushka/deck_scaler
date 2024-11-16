using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class TeamSlotFactory
    {
        private static ProgressData Progress => Services.Get<Progress>().CurrentRun;

        public Entity<Model> Create()
        {
            Progress.AddTeammate();

            return CreateEntity.NewModel()
                               .Add<Name, string>("slot")
                               .Add<TeamSlot, int>(Progress.TeamSize)
                ;
        }
    }
}