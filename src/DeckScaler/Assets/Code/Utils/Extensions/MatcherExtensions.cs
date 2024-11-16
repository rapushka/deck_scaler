using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public static class MatcherExtensions
    {
        public static IMatcher<Entity<TScope>> Without<TScope>(this IMatcher<Entity<TScope>> @this, IMatcher<Entity<TScope>> other)
            where TScope : IScope
            => ScopeMatcher<TScope>.AllOf(@this).NoneOf(other);

        public static IMatcher<Entity<TScope>> Without<TScope, TOtherComponent>(this IMatcher<Entity<TScope>> @this) // TODO: this one doesn't work. but why?
            where TScope : IScope
            where TOtherComponent : IComponent, IInScope<TScope>, new()
            => ScopeMatcher<TScope>.AllOf(@this).NoneOf(ScopeMatcher<TScope>.Get<TOtherComponent>());
    }
}