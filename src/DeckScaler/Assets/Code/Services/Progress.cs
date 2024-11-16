namespace DeckScaler.Service
{
    public class Progress : IService
    {
        public ProgressData CurrentProgress { get; private set; }

        public void StartNewRun()
        {
            CurrentProgress = Services.Get<Configs>().Progress.NewProgressData;
        }
    }
}