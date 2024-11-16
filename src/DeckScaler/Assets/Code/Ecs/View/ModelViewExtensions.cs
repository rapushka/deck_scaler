using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class ModelViewExtensions
    {
        public static Entity<View> AddModel(this Entity<View> @this, Entity<Model> model)
        {
            @this.Add<ModelEntity, Entity<Model>>(model);
            model.Add<ViewEntity, Entity<View>>(@this);

            return @this;
        }

        public static Entity<Model> AddView(this Entity<Model> @this, Entity<View> view)
        {
            view.Add<ModelEntity, Entity<Model>>(@this);
            @this.Add<ViewEntity, Entity<View>>(view);

            return @this;
        }
    }
}