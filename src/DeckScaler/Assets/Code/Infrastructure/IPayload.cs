namespace DeckScaler
{
    public interface IPayload<in TData>
    {
        void SetData(TData data);
    }
}