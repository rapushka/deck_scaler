﻿#if UNITY_EDITOR
using Entitas.VisualDebugging.Unity;
#endif

namespace Entitas.Generic
{
	public class Contexts
	{
		private static Contexts _instance;
		public static Contexts Instance => _instance ??= new Contexts();

		private Contexts() { }

		public void InitializeScope<TScope>()
			where TScope : IScope
		{
			ComponentsLookup<TScope>.Instance.Initialize();
			var context = new ScopeContext<TScope>((e) => new SafeAERC(e));

			InitScopeObserver(context);
		}

		public ScopeContext<TScope> Get<TScope>()
			where TScope : IScope
			=> ScopeContext<TScope>.Instance;

		public IGroup<Entity<TScope>> GetGroup<TScope>(IMatcher<Entity<TScope>> matcher)
			where TScope : IScope
			=> Get<TScope>().GetGroup(matcher);

		public Entity<TScope> SingleOrDefault<TScope>(IMatcher<Entity<TScope>> matcher)
			where TScope : IScope
			=> GetGroup(matcher).GetSingleEntity();

		// ReSharper disable once UnusedParameter.Local – Used in defines
		private void InitScopeObserver(IContext context)
		{
#if UNITY_EDITOR
			if (UnityEngine.Application.isPlaying)
			{
				var observer = new ContextObserver(context);
				UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
			}
#elif GODOT_VISUAL_DEBUGGER && (DEVELOPMENT_BUILD || DEBUG)
			Godot.ContextsDrawer.Observe(context);
#endif
		}
	}
}