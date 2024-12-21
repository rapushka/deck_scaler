using DeckScaler.Component;

namespace DeckScaler
{
    public class StagesUtil
    {
        public void CompleteCurrentStage()
        {
            CreateEntity.Empty()
                .Add<StageCompletedEvent>()
                ;
        }
    }
}