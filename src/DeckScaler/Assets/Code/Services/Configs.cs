using UnityEngine;

namespace DeckScaler.Service
{
    public interface IConfigs : IService
    {
        ICameras Cameras { get; }

        UnitsConfig        Units        { get; }
        ProgressConfig     Progress     { get; }
        SpriteSheet        SpriteSheet  { get; }
        TeamSlotViewConfig TeamSlotView { get; }
        UnitViewConfig     UnitView     { get; }
        UiConfig           Ui           { get; }
    }

    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(Configs))]
    public class Configs : ScriptableObject, IConfigs
    {
        [SerializeField] private Cameras _cameras;

        [field: NaughtyAttributes.Expandable]
        [field: SerializeField] public UnitsConfig Units { get; private set; }

        [field: NaughtyAttributes.Expandable]
        [field: SerializeField] public UnitViewConfig UnitView { get; private set; }

        [field: NaughtyAttributes.Expandable]
        [field: SerializeField] public ProgressConfig Progress { get; private set; }

        [field: NaughtyAttributes.Expandable]
        [field: SerializeField] public SpriteSheet SpriteSheet { get; private set; }

        [field: SerializeField] public TeamSlotViewConfig TeamSlotView { get; private set; }

        [field: NaughtyAttributes.Expandable]
        [field: SerializeField] public UiConfig Ui { get; private set; }

        public ICameras Cameras => _cameras;
    }
}