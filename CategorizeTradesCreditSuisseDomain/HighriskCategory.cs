using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class HighriskCategory : IHandleCategory
    {
        public bool DisplayTradeCategory(DateTime referenceDate, ITrade trade)
        {
            //HIGHRISK
            if (trade.Value > 1000000 &&
                trade.ClientSector.Equals(ClientSectors.Private.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(Categories.HIGHRISK.ToString());
                return true;
            }

            return false;
        }
    }
}
