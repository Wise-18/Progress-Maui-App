using Microsoft.Extensions.Logging;
using ProgressMauiApp.Services;

namespace ProgressMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<CurrencyConverterPage>();
            builder.Services.AddSingleton<IRateService, RateService>();
            builder.Services.AddHttpClient<IRateService, RateService>(client =>
                client.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}