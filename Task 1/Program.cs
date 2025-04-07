using System;

class Program
{
    static int call(int n)
    {
        if(n==0||n==1)
        return 1;
        else
        return n*call(n-1);
    }
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        // int n=5;
        int fact=1;
        
        for(int i=1;i<=n;i++)
        {
            fact*=i;
        }
        // Console.WriteLine(Program.call(n));
        Console.WriteLine(fact);
        Console.Write(Program.call(n));
    }
}
