using MotoMaui.Services;

namespace MotoMaui.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Motorcycle> Motorcycles { get; } = [];
    MainService mainService;

    public MainViewModel(MainService mainService)
    {
        Title = "MotoMaui";
        this.mainService = mainService;

    }

    [RelayCommand]
    async Task Appearing()
    {
        await GetMotorcycles();
    }

    async public Task GetMotorcycles()
    {
        try
        {
            var motorcycles = mainService.GetMotorcycles();

            if (Motorcycles.Count != 0) Motorcycles.Clear();

            foreach (var motorcycle in motorcycles)
            {
                Motorcycles.Add(motorcycle);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Could not get Motorcycle data from file.");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    [RelayCommand]
    async public Task GoToDetails(Motorcycle motorcycle)
    {
        if (motorcycle == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {"Motorcycle", motorcycle }
        });
    }
}

