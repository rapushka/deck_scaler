using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler
{
    public class GameplayFeatureAdapter : FeatureAdapterBase<MainFeature>
    {
        private IEcs _ecsService;

        public void Init(IEcs ecsService) // it's kinda shit:(
        {
            _ecsService = ecsService;
        }

        protected override void MarkAllEntitiesAsDestroyed()
        {
            _ecsService.MarkAllEntitiesAsDestroyed();
        }
    }
}