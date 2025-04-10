using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
}

public class HelloTask
{
    [Runnable]
    public void SayHello()
    {
        Console.WriteLine("Hello from HelloTask!");
    }

    public void SkipThis()
    {
        Console.WriteLine("This should not be executed.");
    }
}

public class MathTask
{
    [Runnable]
    public void PrintSum()
    {
        int a = 10, b = 20;
        Console.WriteLine($"Sum: {a + b}");
    }

    [Runnable]
    public void Multiply()
    {
        int x = 5, y = 4;
        Console.WriteLine($"Product: {x * y}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Discovering and running [Runnable] methods...\n");

        var types = Assembly.GetExecutingAssembly().GetTypes();
        //Console.WriteLine(types);
        foreach (var type in types)
        {
            //Console.WriteLine(type);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var instance = Activator.CreateInstance(type);
            //Console.WriteLine("instance "+ instance);

            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<RunnableAttribute>() != null)
                {
                    Console.WriteLine(method.Name);
                    method.Invoke(instance, null);
                }
            }

        }

        Console.WriteLine("Done executing all [Runnable] methods.");

    }
}
