using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class ModelViewExtensions
    {
        public static Entity<View> AddModel(this Entity<View> @this, Entity<Model> model)
        {
            @this.Add<ModelEntity, EntityModelIDBase>(model.ID());
            model.Add<ViewEntity, EntityViewIDBase>(@this.ID());

            return @this;
        }

        public static Entity<Model> AddView(this Entity<Model> @this, Entity<View> view)
        {
            view.Add<ModelEntity, EntityModelIDBase>(@this.ID());
            @this.Add<ViewEntity, EntityViewIDBase>(view.ID());

            return @this;
        }
    }
}