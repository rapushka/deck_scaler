using SmartIdTable;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<Suit, TMP_Text> _textMeshes;

        public StatsData Stats
        {
            set
            {
                foreach (var (key, textMesh) in _textMeshes)
                    textMesh.text = value[key].ToString();
            }
        }
    }
}