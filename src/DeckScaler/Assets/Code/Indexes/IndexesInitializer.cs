using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public interface IIndexesInitializer : IService
    {
        void Initialize();
    }

    public class IndexesInitializer : IIndexesInitializer
    {
        public void Initialize()
        {
            var context = Contexts.Instance.Get<Game>();

            new SlotPositionPrimaryIndex(context).Initialize();
        }
    }
}