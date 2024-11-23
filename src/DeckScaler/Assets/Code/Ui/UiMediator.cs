namespace DeckScaler.Service
{
    public interface IUiMediator
        : IService
    {
        void EndTurn();

        void SendCheat(string cheat);
    }

    public class UiMediator : IUiMediator
    {
        public void EndTurn() => CreateEntity.OneFrame().Add<Component.EndTurn>();

        public void SendCheat(string cheat) => CreateEntity.Cheat(cheat);
    }
}