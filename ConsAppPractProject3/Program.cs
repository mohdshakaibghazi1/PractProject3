using System;
using System.Collections.Generic;
using System.IO;

namespace PracticeProject3
{
    internal class Program
    {
        public static void InsertionSort(string[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                string key = arr[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(arr[j], key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        //public static void AddNewStudentData(string name, string Class, string filepath, List<string> studentNames, List<string> studentAges)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = File.AppendText(filepath))
        //        {
        //            sw.WriteLine($"{name},{class}");
        //            studentNames.Add(name);
        //            studentclass.Add(class);
        //            Console.WriteLine("New student data added successfully!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        public static void Display(string[] namesArray, List<string> studentNames, List<string> studentgrade)
        {
            foreach (string name in namesArray)
            {
                int index = studentNames.IndexOf(name);
                string grade = studentgrade[index];
                Console.WriteLine($"{name}, class: {grade}");
            }
        }
        public static void Search(string[] namesArray, List<string> studentNames, List<string> studentgrade)
        {
            Console.WriteLine("Enter the name of the student you want to search:");
            string searchName = Console.ReadLine();

            int index = studentNames.IndexOf(searchName);
            if (index >= 0)
            {
                string grade = studentgrade[index];
                Console.WriteLine($"Student found: {searchName}, class: {grade}");
            }
            else
            {
                Console.WriteLine("Student not found in the list.");
            }
        }
        static void Main(string[] args)
        {
            string filepath = "D:\\Mcases\\PracticeProject3.txt";
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                List<string> studentNames = new List<string>();
                List<string> studentgrade = new List<string>();

                foreach (string line in lines)
                {
                    String[] studentdata = line.Split(',');
                    string name = studentdata[0];
                    string grade = studentdata[1];

                    studentNames.Add(name);
                    studentgrade.Add(grade);
                }

                string[] namesArray = studentNames.ToArray();

                InsertionSort(namesArray);

                Console.WriteLine("Sorted Names:");
                Display(namesArray, studentNames, studentgrade);

            //Console.WriteLine("Press 'm' if you want to enter new data");
            //string t = Console.ReadLine();
            //if ( t == "m")
            //{
            //    Console.Write("Enter the name of the new student: ");
            //    string newName = Console.ReadLine();

            //    Console.Write("Enter the grade of the new student: ");
            //    string newgrade = Console.ReadLine();
            //    AddNewStudentData(newName, newgrade, filepath, studentNames, studentgrade);
            //    namesArray = studentNames.ToArray();
            //    InsertionSort(namesArray);

            //    goto result;
            //}
            result:
                Search(namesArray, studentNames, studentgrade);
                Console.WriteLine("Press 'y' if you want to  Search REcord ");
                string t = Console.ReadLine();
                if (t == "y")
                {


                    goto result;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
