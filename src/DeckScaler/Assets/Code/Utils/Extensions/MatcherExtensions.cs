using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public static class MatcherExtensions
    {
        public static IAnyOfMatcher<Entity<Game>> And<TComponent>(this IMatcher<Entity<Game>> @this)
            where TComponent : IComponent, IInScope<Game>, new()
            => @this.And<Game, TComponent>();

        private static IAnyOfMatcher<Entity<TScope>> And<TScope, TComponent>(this IMatcher<Entity<TScope>> @this)
            where TScope : IScope
            where TComponent : IComponent, IInScope<TScope>, new()
            => ScopeMatcher<TScope>.AllOf(@this, ScopeMatcher<TScope>.Get<TComponent>());

        public static IAnyOfMatcher<Entity<Game>> Or<TComponent>(this IMatcher<Entity<Game>> @this)
            where TComponent : IComponent, IInScope<Game>, new()
            => @this.Or<Game, TComponent>();

        private static IAnyOfMatcher<Entity<TScope>> Or<TScope, TComponent>(this IMatcher<Entity<TScope>> @this)
            where TScope : IScope
            where TComponent : IComponent, IInScope<TScope>, new()
            => ScopeMatcher<TScope>.AnyOf(@this, ScopeMatcher<TScope>.Get<TComponent>());

        public static INoneOfMatcher<Entity<Game>> Without<TComponent>(this IMatcher<Entity<Game>> @this)
            where TComponent : IComponent, IInScope<Game>, new()
            => @this.Without<Game, TComponent>();

        private static INoneOfMatcher<Entity<TScope>> Without<TScope, TComponent>(this IMatcher<Entity<TScope>> @this)
            where TScope : IScope
            where TComponent : IComponent, IInScope<TScope>, new()
            => ScopeMatcher<TScope>.AllOf(@this).Without<TScope, TComponent>();

        public static INoneOfMatcher<Entity<Game>> Without<TComponent>(this IAnyOfMatcher<Entity<Game>> @this)
            where TComponent : IComponent, IInScope<Game>, new()
            => @this.Without<Game, TComponent>();

        private static INoneOfMatcher<Entity<TScope>> Without<TScope, TComponent>(this IAnyOfMatcher<Entity<TScope>> @this)
            where TScope : IScope
            where TComponent : IComponent, IInScope<TScope>, new()
            => @this.NoneOf(ScopeMatcher<TScope>.Get<TComponent>());
    }
}