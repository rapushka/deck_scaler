using DeckScaler.Component;
using Entitas;

namespace DeckScaler.Systems
{
    public class StartWithPlayerPrepareStep : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                        .Add<RequestChangeFightStep, FightStep>(FightStep.PlayerPrepare)
                ;
        }
    }
}