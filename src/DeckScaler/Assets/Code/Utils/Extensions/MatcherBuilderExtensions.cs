using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public static class MatcherBuilderExtensions
    {
        public static IGroup<Entity<TScope>> GetGroup<TScope>(this Contexts @this, MatcherBuilder<TScope> builder)
            where TScope : IScope
            => @this.GetGroup(builder.Build());

        public static IGroup<Entity<TScope>> GetGroup<TScope>(this ScopeContext<TScope> @this, MatcherBuilder<TScope> builder)
            where TScope : IScope
            => @this.GetGroup(builder.Build());
    }
}