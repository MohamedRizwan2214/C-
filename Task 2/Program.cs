using System;
class Person{
    string name;
    int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Inroduce()
    {
        Console.WriteLine("Hello, my name is " + name+ " and I am " + age + " years old.");
    }
}
class Program{
    static void Main(string[] args)
    {
        int x=5;
        Console.WriteLine("Hello World!"+ x);
        Person person1 = new Person("John", 30);
        Person person2 = new Person("Jane", 25);
        person1.Inroduce();
        person2.Inroduce();
    }
}