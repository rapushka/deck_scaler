using UnityEngine;

namespace DeckScaler
{
	public class ServicesConfig : MonoBehaviour
	{
		[field: SerializeField] public Camera MainCamera { get; private set; }
		[field: SerializeField] public Camera UiCamera   { get; private set; }
	}
}