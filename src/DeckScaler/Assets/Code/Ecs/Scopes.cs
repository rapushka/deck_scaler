using Entitas.Generic;

namespace DeckScaler
{
    // While we have only one scope – we don't really need to give it a normal name
    public class Scope : IScope { }

    public interface IInScope : IInScope<Scope> { }
}