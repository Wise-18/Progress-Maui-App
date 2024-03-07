using static ProgressMauiApp.CurrencyConverterPage;

namespace ProgressMauiApp.Services
{
    public interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date);
    }
}
