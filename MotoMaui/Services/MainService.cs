namespace MotoMaui.Services;

public class MainService
{
    List<Motorcycle>? motorcycleList;

    public List<Motorcycle> GetMotorcycles()
    {
        try
        {
            if (motorcycleList?.Count > 0)
                return motorcycleList;

            var data = File.ReadAllText("motorcycleData.json");
            motorcycleList = JsonSerializer.Deserialize<List<Motorcycle>>(data);
            return motorcycleList ?? [];
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return [];
        }
    }
}

