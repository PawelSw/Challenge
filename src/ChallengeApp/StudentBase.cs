public delegate void GradeAddedDelegate(object sender, EventArgs args);
public abstract class StudentBase : NamedObject, IStudent
{

    public StudentBase(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;

    public abstract void AddGrade(double grade);

    public abstract void AddGrade(string grade);

    public abstract Statistics GetStatistics();

    public void ShowStatistics()
    {
        var stat = GetStatistics();
        if (stat.Count != 0)
        {
            Console.WriteLine($"{Name} statistics:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Total grades: {stat.Count}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Highest grade: {stat.High:N2}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Lowest grade: {stat.Low:N2}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Average: {stat.Average:N2}");
            Console.WriteLine();
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Couldn't get statistics for {this.Name} because no grade has been added.");
            Console.ResetColor();
        }
    }


}