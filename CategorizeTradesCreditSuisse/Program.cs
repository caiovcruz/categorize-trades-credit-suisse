using CategorizeTradesCreditSuisseDomain;
using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Validators;
using System.Globalization;

Console.WriteLine("Credit Suisse");



DateTime referenceDate;
do
{
    Console.WriteLine("\nReference Date (mm/dd/yyyy):");

    if (DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out referenceDate))
        break;

    Console.WriteLine("\nPlese input the date in correct format! (mm/dd/yyyy)");
}
while (referenceDate == DateTime.MinValue);


int numberOfTrades;
do
{
    Console.WriteLine("\nNumber of Trades:");

    if (int.TryParse(Console.ReadLine(), out numberOfTrades) && numberOfTrades > 0)
        break;

    Console.WriteLine("\nPlease input the number of trades correctly!");
}
while (numberOfTrades <= 0);


var portfolio = new Portfolio(referenceDate, numberOfTrades);


Console.WriteLine("\nTrades");
for (int i = 0; i < numberOfTrades; i++)
{
    var validInfos = false;
    while (!validInfos)
    {
        Console.WriteLine($"[Value] [Client's Sector ({string.Join(',', Enum.GetNames<ClientSectors>())})] [Next Payment (mm/dd/yyyy)]");
        var tradeProperties = typeof(Trade).GetProperties().ToList();
        var trade = Console.ReadLine()?.Split(' ');

        if (trade?.Length == tradeProperties?.Count)
        {
            var tradeValidated = TradeValidator.ValidateTrade(trade[0], trade[1], trade[2]);

            if (tradeValidated != null)
            {
                portfolio.Trades.Add(tradeValidated);
                validInfos = true;
            }
        }

        if (!validInfos)
        {
            Console.WriteLine("\nPlease check the trade's info and try again, info's should be just spaced. Follow the instructions to fill correctly.");
        }
    }
}

Console.WriteLine();
portfolio.DisplayTradesCategory();