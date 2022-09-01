using CategorizeTradesCreditSuisseDomain.Interface;

namespace CategorizeTradesCreditSuisseDomain
{
    public class Trade : ITrade
    {
        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }

        public double Value { get; }

        public string ClientSector { get; }

        public DateTime NextPaymentDate { get; }

        public void HandleTradeCategory(ITrade trade, DateTime referenceDate)
        {
            //Could be upgraded to DI
            var handleCategoryTypes = AppDomain.CurrentDomain
                                                .GetAssemblies()
                                                .SelectMany(assembly => assembly.GetTypes())
                                                .Where(type => typeof(IHandleCategory).IsAssignableFrom(type) && type.IsClass);

            foreach (var handleCategory in handleCategoryTypes)
            {
                if (Activator.CreateInstance(handleCategory) is IHandleCategory handleImplementation)
                {
                    var categoryDisplayed = handleImplementation.DisplayTradeCategory(referenceDate, trade);

                    if (categoryDisplayed)
                        return;
                }
            }
        }
    }
}
