using System;
class Program{
    static void AddChoice(List<string>Names)
    {
        Console.WriteLine("Enter Name to add:");
        string name=Console.ReadLine().ToUpper();
        Names.Add(name);
        Console.WriteLine();
    }
    static void RemoveChoice(List<string>Names)
    {
        Console.WriteLine("Enter Name to remove:");
        string name=Console.ReadLine().ToUpper();
        if(Names.Contains(name))
        {
            Names.Remove(name);
            Console.WriteLine("Name removed successfully.");
        }
        else
        {
            Console.WriteLine("Name not found in the list.");
        }   
    }
    static void DisplayChoice(List<string>Names)
    {
        Console.WriteLine("Names in the list are:");
        for(int i=0;i<Names.Count();i++)
        {
            Console.WriteLine(Names[i]);
        }
    }
    static void Main(string[] args)
    {
        List<string>Names=new List<string>();
        int choice;
        while(true)
        {
            Console.WriteLine("**************");
            Console.WriteLine("Enter Your choice:");
            Console.WriteLine("1.Add Name\n2.Remove Name\n3.Display Names\n4.Exit");
            Console.WriteLine("**************");
            choice=Convert.ToInt32(Console.ReadLine());
            if(choice==4)
            break;
            else if(choice==1)
                AddChoice(Names);
            else if(choice==2)
                RemoveChoice(Names);
            else if(choice==3)
                DisplayChoice(Names);
            else
                Console.WriteLine("Invalid choice, please try again.");
            
        }
    }
}