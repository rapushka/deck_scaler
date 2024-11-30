using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class TrackJustClicked : ReactiveSystem<Entity<Input>>
    {
        public TrackJustClicked() : base(Contexts.Instance.Get<Input>()) { }

        protected override ICollector<Entity<Input>> GetTrigger(IContext<Entity<Input>> context)
            => context.CreateCollector(ScopeMatcher<Input>.Get<Pressed>().Added());

        protected override bool Filter(Entity<Input> cursor) => cursor.Is<Pressed>();

        protected override void Execute(List<Entity<Input>> cursors)
        {
            foreach (var cursor in cursors)
                cursor.Is<JustClicked>(true);
        }
    }
}