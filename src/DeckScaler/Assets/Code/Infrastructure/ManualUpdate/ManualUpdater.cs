using UnityEngine;

namespace DeckScaler.Service
{
    public interface IManualUpdater : IService
    {
        void Initialize(params IUpdatable[] updatables);

        void Dispose();
    }

    public class ManualUpdater : IManualUpdater
    {
        private UpdaterBehaviour _updater;

        public void Initialize(params IUpdatable[] updatables)
        {
            _updater = new GameObject("Manual Updater")
                .AddComponent<UpdaterBehaviour>();

            _updater.Add(updatables);
        }

        public void Dispose()
        {
            _updater.Clear();
            _updater.DestroyObject();
            _updater = null;
        }
    }
}