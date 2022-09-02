using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class ExpiredCategory : HandleCategory
    {
        public ExpiredCategory(DateTime referenceDate, ITrade trade) : base(referenceDate, trade) { }

        public override bool DisplayTradeCategory()
        {
            //EXPIRED
            if (IsExpiredTrade())
            {
                Console.WriteLine(Categories.EXPIRED.ToString());
                return true;
            }

            return false;
        }
    }
}
