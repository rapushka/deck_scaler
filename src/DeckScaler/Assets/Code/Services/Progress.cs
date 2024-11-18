namespace DeckScaler.Service
{
    public interface IProgress : IService
    {
        ProgressData CurrentRun { get; }

        void StartNewRun();
    }

    public class Progress : IProgress
    {
        private static IConfigs Configs => Services.Get<IConfigs>();

        public ProgressData CurrentRun { get; private set; }

        public void StartNewRun()
        {
            CurrentRun = Configs.Progress.NewProgressData;
        }
    }
}