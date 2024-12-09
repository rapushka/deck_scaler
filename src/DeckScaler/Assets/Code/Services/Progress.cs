namespace DeckScaler.Service
{
    public interface IProgress : IService
    {
        ProgressData CurrentRun { get; }

        void StartNewRun();
    }

    public class Progress : IProgress
    {
        private static IConfigs Configs => ServiceLocator.Get<IConfigs>();

        public ProgressData CurrentRun { get; private set; }

        public void StartNewRun()
        {
            CurrentRun = ProgressData.NewRun(from: Configs.Progress.NewProgressData);
        }
    }
}