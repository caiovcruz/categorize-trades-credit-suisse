using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public interface IHandleCategory
    {
        DateTime ReferenceDate { get; }
        ITrade Trade { get; }

        bool DisplayTradeCategory();

        public bool IsExpiredTrade();

        public bool IsHighriskTrade();

        public bool IsMediumriskTrade();

        public bool IsPEPTrade();
    }
}
