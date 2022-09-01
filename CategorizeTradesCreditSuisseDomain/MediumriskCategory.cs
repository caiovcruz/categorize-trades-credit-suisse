using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class MediumriskCategory : IHandleCategory
    {

        public bool DisplayTradeCategory(DateTime referenceDate, ITrade trade)
        {
            //MEDIUMRISK
            if (trade.Value > 1000000 &&
                trade.ClientSector.Equals(ClientSectors.Public.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(Categories.MEDIUMRISK.ToString());
                return true;
            }

            return false;
        }
    }
}
