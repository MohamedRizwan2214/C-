using System;
class Program
{
    static async Task<string> callApi(string apiName, int delay)
    {
        try{
            Console.WriteLine($"Calling {apiName}...");
            await Task.Delay(delay); 
            return $"{apiName} responded after {delay} ms.";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return $"Error calling {apiName}";
        }
    }
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting Data Fetch");
        try
        {
            List<Task<string>> tasks=new List<Task<string>>();
            tasks.Add(callApi("API1",1000));
            tasks.Add(callApi("API2",1500));
            tasks.Add(callApi("API3",800));

            string[] results = await Task.WhenAll(tasks);
            Console.WriteLine("All API calls completed successfully.");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Data Fetch Completed");
        }
    }

}