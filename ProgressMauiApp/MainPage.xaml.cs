using System.Security.AccessControl;

namespace ProgressMauiApp
{
    public partial class MainPage : ContentPage
    {
        private CancellationTokenSource _cancellationTokenSource;

        public MainPage() => InitializeComponent();

        private async void OnStartClicked(object sender, EventArgs e)
        {
            lbl_title.Text = "Вычисление";
            btn_start.IsEnabled = false;
            btn_cancel.IsEnabled = true;

            await CalculateIntegralAsync();

        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            btn_cancel.IsEnabled = false;
            btn_start.IsEnabled = true;
            progress_bar.Progress = 0;
        }

        public async Task CalculateIntegralAsync()
        {
           await Task.Run(async () =>
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationTokenSource.Token.Register(() =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        lbl_title.Text = "Задание отменено";
                        btn_start.IsEnabled = true;
                        progress_bar.Progress = 0;
                    });
                });

                double step = 0.00000001;
                double sum = 0.0;
                double numberOfSteps = 1 / step;

                for (double x = 0; x < 1; x += step)
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        return; // Операция отменена
                    }

                    // Имитация длительных вычислений
                    for (int i = 0; i < 100000; i++)
                    {
                        int result = i * i; // Простой пример вычисления
                    }

                    sum += Math.Sin(x) * step;

                    double progress = x / numberOfSteps;

                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        progress_bar.Progress = x;

                    });
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    lbl_title.Text = $"Результат: {sum}";
                    btn_cancel.IsEnabled = false;
                    btn_start.IsEnabled = true;
                });
            });
        }

        private async void btn_converter_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(MauiProgram.CreateMauiApp().Services.GetRequiredService<CurrencyConverterPage>());
        }
    }
}