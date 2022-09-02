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
                                                .Where(type => typeof(IHandleCategory).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);

            foreach (var handleCategory in handleCategoryTypes)
            {
                if (Activator.CreateInstance(handleCategory, referenceDate, trade) is IHandleCategory handleImplementation)
                {
                    var categoryDisplayed = handleImplementation.DisplayTradeCategory();

                    if (categoryDisplayed)
                        return;
                }
            }
        }
    }
}
