using DeckScaler.Component;
using Entitas;

namespace DeckScaler
{
    public sealed class RequireSpawnStagesOnInit : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.OneFrame()
                .Add<RequireSpawnStages>();
        }
    }
}