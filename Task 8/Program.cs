using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntity
{
    int id{get; set;}
}
public class Student : IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}

public interface IRepository<T> where T : IEntity
{
    void Add(T entity);
    T Get(int id);
    List<T> GetAll();
    void Update(T entity);
    void Delete(int id);
}

public class Curd<T>:IRepository<T> where T : IEntity
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T Get(int id)
    {
        foreach (var item in items)
        {
            if (item is IEntity entity && entity.id == id)
            {
                return item;
            }
        }
        return default;
    }


    public List<T> GetAll()
    {
        return items;
    }
    

    public void Update(T item)
    {
        var existingitem = Get(item.id);
        if (existingitem != null)
        {
            items.Remove(existingitem);
            items.Add(item);
        }
    }

    public void Delete(int id)
    {
        var entity = Get(id);
        if (entity != null)
        {
            items.Remove(entity);
        }
    }
}
class Program
{

    static void Main(string[] args)
    {
        IRepository<Student> studentRepository = new Curd<Student>();
        int choice ;
        studentRepository.Add(new Student { id = 1, name = "John Doe" });
        studentRepository.Add(new Student { id = 2, name = "Jane Smith" });
        int id=2;
        while(true)
        {
            Console.WriteLine("**************");
            Console.WriteLine("Enter Your choice:");
            Console.WriteLine("1.Add Student\n2.View All Students\n3.Get Student Detail\n4.Update Student\n5.Delete Student\n6.Exit");
            Console.WriteLine("**************");
            
    
            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                id++;
                Console.WriteLine("Enter Student Name:");
                string name = Console.ReadLine();
                studentRepository.Add(new Student { id = id, name = name });
                Console.WriteLine("Student Added Successfully!");

            }
            else if (choice == 2)
            {
                Console.WriteLine("All Students:");
                var studentDetails=studentRepository.GetAll();
                foreach (var s in studentDetails)
                {
                    Console.WriteLine($"ID: {s.id}, Name: {s.name}");
                }

            }
            else if(choice == 3)
            {
                Console.WriteLine("Enter Student ID to get details:");
                int studentId = Convert.ToInt32(Console.ReadLine());
                var student=studentRepository.Get(studentId);
                if (student != null)
                {
                    Console.WriteLine($"Found Student: ID: {student.id}, Name: {student.name}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Enter Student ID to update:");
                int studentId = Convert.ToInt32(Console.ReadLine());
                var student=studentRepository.Get(studentId);
                if(student!=null)
                {
                    Console.WriteLine($"Found Student: ID: {student.id}, Name: {student.name}");
                    Console.WriteLine("Enter new name:");
                    string newName = Console.ReadLine();
                    student.name = newName;
                    studentRepository.Update(student);
                    Console.WriteLine("Student Updated Successfully!");
                    Console.WriteLine("After Update:");
                    foreach (var s in studentRepository.GetAll())
                    {
                        Console.WriteLine($"ID: {s.id}, Name: {s.name}");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
                
            }
            else if (choice == 5)
            {
                Console.WriteLine("Enter Student ID to delete:");
                int studentId = Convert.ToInt32(Console.ReadLine());
                var student=studentRepository.Get(studentId);
                if(student!=null)
                {
                    studentRepository.Delete(studentId);
                    Console.WriteLine("After Delete:");
                    foreach (var s in studentRepository.GetAll())
                    {
                        Console.WriteLine($"ID: {s.id}, Name: {s.name}");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
                
            }
            else if (choice == 6)
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        
            
        }




        
        
        // Console.WriteLine("All Students:");
        // foreach (var s in studentRepository.GetAll())
        // {
        //     Console.WriteLine($"ID: {s.id}, Name: {s.name}");
        // }


        // var student=studentRepository.Get(1);
        // if (student != null)
        // {
        //     Console.WriteLine($"Found Student: ID: {student.id}, Name: {student.name}");
        // }
        // else
        // {
        //     Console.WriteLine("Student not found.");
        // }

        // studentRepository.Update(new Student { id = 1, name = "John Doe Updated" });
        // Console.WriteLine("After Update:");
        // foreach (var s in studentRepository.GetAll())
        // {
        //     Console.WriteLine($"ID: {s.id}, Name: {s.name}");
        // }

        // studentRepository.Delete(1);
        // Console.WriteLine("After Delete:");
        // foreach (var s in studentRepository.GetAll())
        // {
        //     Console.WriteLine($"ID: {s.id}, Name: {s.name}");
        // }
    }
}