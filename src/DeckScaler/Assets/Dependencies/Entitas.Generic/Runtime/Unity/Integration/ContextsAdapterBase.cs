#if ENTITAS_GENERIC_UNITY_SUPPORT
using UnityEngine;

namespace Entitas.Generic
{
	public abstract class ContextsAdapterBase : MonoBehaviour
	{
		private void Awake() => Initialize(Contexts.Instance);

		protected abstract void Initialize(Contexts contexts);
	}
}
#endif