namespace DeckScaler.Service
{
    public interface IUiMediator
        : IService
    {
        void EndTurn();
    }

    public class UiMediator : IUiMediator
    {
        public void EndTurn()
        {
            CreateEntity.OneFrame()
                        .Add<Component.EndTurn>();
        }
    }
}