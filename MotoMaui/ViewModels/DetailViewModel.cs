namespace MotoMaui.ViewModels;

[QueryProperty(nameof(Motorcycle), "Motorcycle")]
public partial class DetailViewModel : BaseViewModel
{
    [ObservableProperty]
    Motorcycle motorcycle;
}

