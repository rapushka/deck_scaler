namespace Entitas.Generic
{
	public interface IListener<TScope, in TComponent>
		where TScope : IScope
		where TComponent : IComponent, IEvent, IInScope<TScope>
	{
		void OnValueChanged(Entity<TScope> entity, TComponent component);
	}
}