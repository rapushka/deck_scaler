using DeckScaler.Service;

namespace DeckScaler.Editor.Tests.Mocks
{
    public class Progress : IProgress
    {
        public ProgressData CurrentRun { get; set; }

        public void StartNewRun()
        {
            CurrentRun = new ProgressData();
        }
    }
}