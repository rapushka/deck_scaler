using DeckScaler.Component;

namespace DeckScaler
{
    public class RerollButton : BaseButton
    {
        protected override void OnClick()
        {
            CreateEntity.Empty()
                .Add<RequestReroll>()
                ;
        }
    }
}