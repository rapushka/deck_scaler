using Entitas.Generic;

namespace DeckScaler
{
    // While we have only one scope – we don't really need to give it a normal name
    public class Scope : IScope { }

    public interface IInScope : IInScope<Scope> { }

    public class Entity : Entity<Scope> { }

    public static class ContextsExtensions
    {
        public static ScopeContext<Scope> Scope(this Contexts @this) => @this.Get<Scope>();
    }
}