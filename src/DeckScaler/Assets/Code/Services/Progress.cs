namespace DeckScaler.Service
{
    public class Progress : IService
    {
        public ProgressData CurrentRun { get; private set; }

        public void StartNewRun()
        {
            CurrentRun = Services.Get<Configs>().Progress.NewProgressData;
        }
    }
}