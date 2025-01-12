using UnityEngine;

namespace DeckScaler.Service
{
    public interface IConfigs : IService
    {
        ICameras Cameras { get; }

        UnitsConfig Units { get; }
    }

    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(Configs))]
    public class Configs : ScriptableObject, IConfigs
    {
        [SerializeField] private Cameras _cameras;

        [field: NaughtyAttributes.BoxGroup(nameof(UnitsConfig))]
        [field: SerializeField] public UnitsConfig Units { get; private set; }

        public ICameras Cameras => _cameras;
    }
}