using System;
using System.IO;
class Program
{
    static void WriteFile(string FileName,int wordCount, int lineCount)
    {
        try
        {
            File.WriteAllText(FileName, $"Number of lines: {lineCount}\nNumber of words: {wordCount}");
            Console.WriteLine("File written successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"I/O Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred: {e.Message}");
        }
    }
    static void Main(string[] args)
    {
        string FileName="task.txt";
        try
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("The input file was not found", FileName);
            }
            string[] lines = File.ReadAllLines(FileName);
            int lineCount = lines.Length;
            int wordCount = 0;
            foreach (string line in lines)
            {
                wordCount += line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
            // Console.WriteLine($"Number of lines: {lineCount}");
            // Console.WriteLine($"Number of words: {wordCount}");
            WriteFile("output.txt",wordCount,lineCount);
            Console.WriteLine("Completed successfully.");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"I/O Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred: {e.Message}");
        }

    }
    
}