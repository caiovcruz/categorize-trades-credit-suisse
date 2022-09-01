using CategorizeTradesCreditSuisseDomain.Enum;
using System.Globalization;

namespace CategorizeTradesCreditSuisseDomain.Validators
{
    public static class TradeValidator
    {
        public static Trade? ValidateTrade(string strValue, string strClientSector, string strNextPaymentDate)
        {
            if (double.TryParse(strValue, out double value) &&
            System.Enum.TryParse(strClientSector, out ClientSectors clientSector) &&
            DateTime.TryParseExact(strNextPaymentDate,
                                    "MM/dd/yyyy",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime nextPaymentDate))
            {
                return new Trade(value, clientSector.ToString(), nextPaymentDate);
            }

            return null;
        }
    }
}
