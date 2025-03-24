using System;

public delegate string TimeHandler(DateTime dateTime);
public class TimeFormatter
{
    public string FormatTime(DateTime dateTime)
    {
        return $"Текущее время: {dateTime:HH:mm:ss}";
    }
}
public class DateFormatter
{
    public string FormatDate(DateTime dateTime)
    {
        return $"Сегодня: {dateTime:dd.MM.yyyy}";
    }
}
class Program
{
    static void Main()
    {
        DateTime now = DateTime.Now;

        TimeFormatter timeFormatter = new TimeFormatter();
        DateFormatter dateFormatter = new DateFormatter();

        TimeHandler timeDelegate;

        timeDelegate = timeFormatter.FormatTime;
        Console.WriteLine(timeDelegate(now));

        timeDelegate = dateFormatter.FormatDate;
        Console.WriteLine(timeDelegate(now));
    }
}

