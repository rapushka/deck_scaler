using DeckScaler.Component;
using Entitas;

namespace DeckScaler.Systems
{
    public class StartWithPlayerPrepareStep : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.OneFrame()
                        .Add<RequestChangeFightStep, FightStep>(FightStep.PlayerPrepare)
                ;
        }
    }
}