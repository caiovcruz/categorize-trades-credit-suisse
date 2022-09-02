using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class MediumriskCategory : HandleCategory
    {
        public MediumriskCategory(DateTime referenceDate, ITrade trade) : base(referenceDate, trade) { }

        public override bool DisplayTradeCategory()
        {
            //MEDIUMRISK
            if (IsMediumriskTrade())
            {
                Console.WriteLine(Categories.MEDIUMRISK.ToString());
                return true;
            }

            return false;
        }
    }
}
