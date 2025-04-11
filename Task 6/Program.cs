using System;
public delegate void ThresholdReachHandler(int count);

public class Counter
{
    public event ThresholdReachHandler ThreshodReached;
    private int count = 0;
    private int threshhold = 5;
    
    public void Increment()
    {
        count++;
        Console.WriteLine($"Count: {count}");
        if(count==threshhold)
        {
            ThreshodReached?.Invoke(count);
        }
    }

}

public class EventHandlers
{
    public static void ShowAlert(int count)
    { 
        Console.WriteLine($"[ALERT] Count reached: {count}"); 
    }
    public static void LogEvent(int count)
    {
        Console.WriteLine($"[LOG] Event at count: {count}");
    }

}

class Program
{

    static void Main(String[] args)
    {
        Counter counter = new Counter();

        counter.ThreshodReached += EventHandlers.ShowAlert;
        counter.ThreshodReached += EventHandlers.LogEvent;

        for (int i=0;i<10;i++)
        {
            counter.Increment();
        }

        // while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        // {
        //     Console.WriteLine($"You pressed: {Console.ReadKey(true).Key}");
        // }
    }
}