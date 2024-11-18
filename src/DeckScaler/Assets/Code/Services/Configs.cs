using UnityEngine;

namespace DeckScaler.Service
{
    public interface IConfigs : IService
    {
        UnitsConfig    Units       { get; }
        ProgressConfig Progress    { get; }
        SpriteSheet    SpriteSheet { get; }
    }

    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(Configs))]
    public class Configs : ScriptableObject, IConfigs
    {
        [field: SerializeField] public UnitsConfig    Units    { get; private set; }
        [field: SerializeField] public ProgressConfig Progress { get; private set; }

        [field: SerializeField] public SpriteSheet SpriteSheet { get; private set; }
    }
}