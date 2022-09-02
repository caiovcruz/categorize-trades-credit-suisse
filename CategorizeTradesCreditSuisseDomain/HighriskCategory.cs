using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class HighriskCategory : HandleCategory
    {
        public HighriskCategory(DateTime referenceDate, ITrade trade) : base(referenceDate, trade) { }

        public override bool DisplayTradeCategory()
        {
            //HIGHRISK
            if (IsHighriskTrade())
            {
                Console.WriteLine(Categories.HIGHRISK.ToString());
                return true;
            }

            return false;
        }
    }
}
