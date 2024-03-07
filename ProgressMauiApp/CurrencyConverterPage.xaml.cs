using ProgressMauiApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProgressMauiApp;

public partial class CurrencyConverterPage : ContentPage, INotifyPropertyChanged
{
    private ObservableCollection<Rate> rates = new ObservableCollection<Rate>();
    private string number2;

    public ObservableCollection<Rate> Rates
    {
        get => rates;
        set
        {
            rates = value;
            OnPropertyChanged();
        }
    }

    public DateTime SelectedDate { get; set; } = DateTime.Now;
    public Rate SelectedRate { get; set; }
    public bool IsReverse { get; set; }
    public string Number { get; set; }
    public string Number2
    {
        get { return number2; }
        set
        {
            number2 = value;
            OnPropertyChanged();
        }
    }

    public IRateService _rateService { get; }
    public CurrencyConverterPage(IRateService rateService)
	{
        InitializeComponent();
        _rateService = rateService;

        BindingContext = this;
        foreach (var item in rateService.GetRates(SelectedDate))
            Rates.Add(item);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (SelectedDate > DateTime.Now) return;

        Rates.Clear();

        foreach (var item in _rateService.GetRates(SelectedDate))
            Rates.Add(item);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (SelectedRate == null) return;

        decimal num = decimal.Parse(Number);

        if (!IsReverse)
            Number2 = (num * (1 / SelectedRate.Cur_OfficialRate))?.ToString();
        else
            Number2 = (num * SelectedRate.Cur_OfficialRate).ToString();
    }
}