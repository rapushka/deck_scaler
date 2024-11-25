using UnityEngine;

namespace DeckScaler.Systems
{
    public struct EndlessLoopPreventor
    {
        private int _counter;

        private EndlessLoopPreventor(int counter)
        {
            _counter = counter;
        }

        public static EndlessLoopPreventor New(int counter = 1_000) => new(counter);

        public bool Continue
        {
            get
            {
                var result = _counter-- > 0;

                if (result is false)
                    Debug.LogError("Just prevented an endless loop!");

                return result;
            }
        }
    }
}