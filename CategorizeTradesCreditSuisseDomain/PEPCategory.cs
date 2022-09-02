using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class PEPCategory : HandleCategory
    {
        public PEPCategory(DateTime referenceDate, ITrade trade) : base(referenceDate, trade) { }

        public override bool DisplayTradeCategory()
        {
            //MEDIUMRISK
            if (IsPEPTrade())
            {
                Console.WriteLine(Categories.PEP.ToString());
                return true;
            }

            return false;
        }
    }
}
