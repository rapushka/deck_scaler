using UnityEngine;

namespace DeckScaler
{
    public class RecruitmentStageView : MonoBehaviour
    {
        [field: SerializeField] public Transform UnitsRoot { get; private set; }
        [field: SerializeField] public float     Spacing   { get; private set; }
    }
}