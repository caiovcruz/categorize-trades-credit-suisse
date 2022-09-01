using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public interface IHandleCategory
    {
        bool DisplayTradeCategory(DateTime referenceDate, ITrade trade);
    }
}
