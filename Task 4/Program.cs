using System;
using System.Linq;
public class Student{
    public string name;
    public int age;
    public int grade;
    public Student(string name, int age, int grade)
    {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }
}
class Program{
    static void Main(string[] args)
    {
        List<Student> students=new List<Student>();
        students.Add(new Student("John", 20, 90));
        students.Add(new Student("Alice", 22, 85));
        students.Add(new Student("Bob", 19, 92));
        students.Add(new Student("Eve", 21, 88));
        students.Add(new Student("Charlie", 23, 80));
        students.Add(new Student("Diana", 20, 95));
        students.Add(new Student("Frank", 22, 78));
        students.Add(new Student("Grace", 24, 82));
        students.Add(new Student("Hank", 19, 89));
        students.Add(new Student("Ivy", 21, 91));
        students.Add(new Student("Jack", 20, 87));

        var filtered= from student in students 
                        where student.grade>85
                        orderby student.name descending
                        select student;

        foreach(var student in filtered)
        {
            Console.WriteLine("Name: " + student.name + ", Age: " + student.age + ", Grade: " + student.grade);
        }

        // int [] n={1,2,3,4,5};
        // var en=from num in n
        //        where num>80
        //        orderby num descending
        //        select num;
        // foreach (var item in en)
        // {
        //     Console.WriteLine(item);
        // }
    }
}