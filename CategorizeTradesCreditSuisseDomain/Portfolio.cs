using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class Portfolio : IPortfolio
    {
        public Portfolio(DateTime referenceDate, int numberOfTrades)
        {
            ReferenceDate = referenceDate;
            NumberOfTrades = numberOfTrades;
            Trades = new List<ITrade>();
        }

        public DateTime ReferenceDate { get; }
        public int NumberOfTrades { get; }
        public List<ITrade> Trades { get; set; }

        public void DisplayTradesCategory()
        {
            if (Trades?.Count > 0)
            {
                Trades.ForEach(trade => trade.HandleTradeCategory(trade, ReferenceDate));
            }
            else
            {
                Console.WriteLine("This portfolio doesn't contain any trade.");
            }
        }
    }
}
