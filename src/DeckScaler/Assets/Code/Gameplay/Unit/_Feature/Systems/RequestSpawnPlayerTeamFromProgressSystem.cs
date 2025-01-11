using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public sealed class RequestSpawnPlayerTeamFromProgressSystem : IInitializeSystem
    {
        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var unitID in Progress.TeammateIDs)
            {
                CreateEntity.Empty()
                    .Add<SpawnUnitRequest, UnitIDRef>(unitID)
                    .Add<OnSide, Side>(Side.Player)
                    ;
            }
        }
    }
}