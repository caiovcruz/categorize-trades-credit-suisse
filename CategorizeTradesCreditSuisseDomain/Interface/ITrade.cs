namespace CategorizeTradesCreditSuisseDomain.Interface
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }

        void HandleTradeCategory(ITrade trade, DateTime referenceDate);
    }
}
