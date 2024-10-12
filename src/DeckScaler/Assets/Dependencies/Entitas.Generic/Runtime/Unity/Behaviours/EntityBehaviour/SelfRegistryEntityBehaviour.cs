#if ENTITAS_GENERIC_UNITY_SUPPORT
namespace Entitas.Generic
{
	public interface ISelfRegistry { }

	public abstract class SelfRegistryEntityBehaviour<TScope> : EntityBehaviour<TScope>, ISelfRegistry
		where TScope : IScope
	{
		private void Start()
		{
			Register(Contexts.Instance);
		}
	}
}
#endif