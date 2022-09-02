using CategorizeTradesCreditSuisseDomain.Enum;
using System.Globalization;

namespace CategorizeTradesCreditSuisseDomain.Validators
{
    public static class TradeValidator
    {
        public static Trade? ValidateTrade(string strValue, string strClientSector, string strNextPaymentDate, string strIsPoliticallyExposed)
        {
            if (double.TryParse(strValue, out double value) &&
            System.Enum.TryParse(strClientSector, out ClientSectors clientSector) &&
            DateTime.TryParseExact(strNextPaymentDate,
                                    "MM/dd/yyyy",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime nextPaymentDate) &&
            bool.TryParse(strIsPoliticallyExposed, out bool isPoliticallyExposed))
            {
                return new Trade(value, clientSector.ToString(), nextPaymentDate, isPoliticallyExposed);
            }

            return null;
        }
    }
}
