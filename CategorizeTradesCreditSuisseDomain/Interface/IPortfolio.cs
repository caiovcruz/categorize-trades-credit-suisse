using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public interface IPortfolio
    {
        DateTime ReferenceDate { get; }
        int NumberOfTrades { get; }
        List<ITrade> Trades { get; set; }

        void DisplayTradesCategory();
    }
}
