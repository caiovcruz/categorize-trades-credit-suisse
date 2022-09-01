using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class ExpiredCategory : IHandleCategory
    {
        public bool DisplayTradeCategory(DateTime referenceDate, ITrade trade)
        {
            //EXPIRED
            if ((referenceDate - trade.NextPaymentDate).Days > 30)
            {
                Console.WriteLine(Categories.EXPIRED.ToString());
                return true;
            }

            return false;
        }
    }
}
