namespace Entitas.Generic
{
	public partial class UniqueComponentsContainer<TScope>
	{
		private Entity<TScope> Add<TComponent, TValue>(TValue value)
			where TComponent : ValueComponent<TValue>, IUnique, IInScope<TScope>, new()
		{
			if (Has<TComponent>())
				throw AlreadyHasComponentException<TComponent>();

			return Create<TComponent, TValue>(value);
		}
	}
}