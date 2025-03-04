using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk7Ex3
{
    // Student class to store student data
    public class Student
    {
        public string Name { get; set; }
        public string Grade { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFileName = "students.csv"; // CSV file containing student data

            // Read the CSV file and store student data in list
            List<Student> students = ReadCSV(csvFileName);

            // Display the student data
            if (students.Count > 0)
            {
                // Display student data
                Console.WriteLine("Student Grades:");
                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
                }
            }
            else
            {
                Console.WriteLine("No student data found.");
            }
        }

        // Method to read student data from a CSV file
        static List<Student> ReadCSV(string fileName)
        {
            List<Student> students = new List<Student>();

            // Check if the file exists before attempting to read
            if (!File.Exists(fileName))
            {
                Console.WriteLine("CSV file not found.");
                return students;
            }

            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                // Split each line by comma
                string[] parts = line.Split(',');

                // Check if the line has two parts
                if (parts.Length == 2) 
                {
                    students.Add(new Student
                    {
                        Name = parts[0].Trim(),
                        Grade = parts[1].Trim()
                    });
                }
            }

            return students;
        }
    }
}
