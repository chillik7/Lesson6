using System;
public class WeatherChangedEventArgs : EventArgs
{
    public string Conditions { get; }

    public WeatherChangedEventArgs(string conditions)
    {
        Conditions = conditions;
    }
}
public class WeatherStation
{
    public event EventHandler<WeatherChangedEventArgs> WeatherChanged;

    public void UpdateWeather(string conditions)
    {
        Console.WriteLine($"[WeatherStation] Новые погодные условия: {conditions}");
        WeatherChanged?.Invoke(this, new WeatherChangedEventArgs(conditions));
    }
}
public class DisplayPanel
{
    public void OnWeatherChanged(object sender, WeatherChangedEventArgs e)
    {
        Console.WriteLine($"[DisplayPanel] Обновление отображения: {e.Conditions}");
    }
}
public class WarningSystem
{
    public void OnWeatherChanged(object sender, WeatherChangedEventArgs e)
    {
        if (e.Conditions.Contains("шторм"))
        {
            Console.WriteLine("[WarningSystem] ВНИМАНИЕ! Штормовое предупреждение!");
        }
    }
}
public class WeatherMonitor
{
    private WeatherStation _station;

    public WeatherMonitor(WeatherStation station)
    {
        _station = station;
    }
    public void Subscribe(DisplayPanel display, WarningSystem warning)
    {
        _station.WeatherChanged += display.OnWeatherChanged;
        _station.WeatherChanged += warning.OnWeatherChanged;
    }
    public void Unsubscribe(DisplayPanel display, WarningSystem warning)
    {
        _station.WeatherChanged -= display.OnWeatherChanged;
        _station.WeatherChanged -= warning.OnWeatherChanged;
    }
}
class Program
{
    static void Main()
    {
        WeatherStation station = new WeatherStation();
        DisplayPanel display = new DisplayPanel();
        WarningSystem warning = new WarningSystem();
        WeatherMonitor monitor = new WeatherMonitor(station);

        monitor.Subscribe(display, warning);

        station.UpdateWeather("Ясно, +25°C");
        station.UpdateWeather("Дождь, +18°C");
        station.UpdateWeather("Сильный шторм, +10°C");

        monitor.Unsubscribe(display, warning);
    }
}

