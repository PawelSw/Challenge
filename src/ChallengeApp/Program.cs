using System;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        bool CloseApp = false;

        while (!CloseApp)
        {
            Console.WriteLine(

                "1 - Add student's grades to the program memory and show statistics\n" +
                "2 - Add student's grades to the .txt file and show statistics\n" +
                "X - Close app\n");

            var userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "1":
                    AddGradesToMemory();
                    break;

                case "2":
                    AddGradesToTxtFile();
                    break;

                case "X":
                    CloseApp = true;
                    break;

                default:
                    System.Console.WriteLine("Invalid operation.\n");
                    continue;
            }
        }

        static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {student.Name}.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    student.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Please provide numbers instead of letters. {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Press 'q' to show {student.Name} statistics.");
                }
            }
        }

        static void AddGradesToTxtFile()
        {
            System.Console.WriteLine("Type the name of the student:");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                var student = new StudentInFile(name);
                student.GradeAdded += OnGradeAdded;
                EnterGrade(student);
                student.ShowStatistics();
            }
            else
            {
                System.Console.WriteLine("Name can not be empty, please try again.");
            }

            static void OnGradeAdded(object sender, EventArgs args)
            {
                System.Console.WriteLine("Oh no! We should inform student’s parents about this fact.");
            }
        }

        static void AddGradesToMemory()
        {
            System.Console.WriteLine("Type the name of the student:");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                var student = new StudentInMemory(name);
                student.GradeAdded += OnGradeAdded;
                EnterGrade(student);
                student.ShowStatistics();
            }
            else
            {
                System.Console.WriteLine("Name can not be empty, please try again.");
            }

            static void OnGradeAdded(object sender, EventArgs args)
            {
                System.Console.WriteLine("Oh no! We should inform student’s parents about this fact.");
            }
        }
    }
}













