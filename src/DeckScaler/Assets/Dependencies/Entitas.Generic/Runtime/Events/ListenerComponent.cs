﻿using System.Collections.Generic;

namespace Entitas.Generic
{
	public class ListenerComponent<TScope, TComponent> : IComponent, IInScope<TScope>
		where TScope : IScope
		where TComponent : IComponent, IEvent, IInScope<TScope>
	{
		public List<IListener<TScope, TComponent>> Value;
	}
}