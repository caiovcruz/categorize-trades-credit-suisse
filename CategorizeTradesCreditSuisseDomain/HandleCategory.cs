using CategorizeTradesCreditSuisseDomain.Enum;
using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public abstract class HandleCategory : IHandleCategory
    {
        public HandleCategory(DateTime referenceDate, ITrade trade)
        {
            ReferenceDate = referenceDate;
            Trade = trade;
        }

        public DateTime ReferenceDate { get; }

        public ITrade Trade { get;  }


        public virtual bool DisplayTradeCategory()
        {
            return false;
        }

        public bool IsExpiredTrade() => (ReferenceDate - Trade.NextPaymentDate).Days > 30;

        public bool IsHighriskTrade() => Trade.Value > 1000000 &&
                                              Trade.ClientSector.Equals(ClientSectors.Private.ToString(),
                                                                        StringComparison.OrdinalIgnoreCase)
                                                               && !IsExpiredTrade();

        public bool IsMediumriskTrade() => Trade.Value > 1000000 &&
                                              Trade.ClientSector.Equals(ClientSectors.Public.ToString(),
                                                                        StringComparison.OrdinalIgnoreCase)
                                                               && !IsExpiredTrade();
    }
}
