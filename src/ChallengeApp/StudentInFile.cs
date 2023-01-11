public class StudentInFile : StudentBase
{
    private List<double> grades;
    private const string filename = "Grades.txt";
    private const string audit = "Audit.txt";
    public StudentInFile(string name) : base(name)
    {
        grades = new List<double>();
    }
    public void ChangeStudentName(string newName)
    {
        string oldName = this.Name;
        foreach (char c in newName)
        {
            if (char.IsDigit(c))
            {
                this.Name = oldName;
                System.Console.WriteLine($"Name can not be changed cause it includes digits.");
                break;
            }
            else
            {
                this.Name = newName;
                System.Console.WriteLine($"The name was changed into: {newName}.");
            }
        }
    }

    public override event GradeAddedDelegate GradeAdded;
    public override void AddGrade(double grade)
    {
        using (var writer = File.AppendText(Name + "." + filename))
        {
            using (var writer2 = File.AppendText(Name + "." + audit))
            {
                if (grade > 0 && grade <= 6)
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine(grade + " " + DateTime.UtcNow.ToString());
                    if (GradeAdded != null && (grade <= 3 && grade >= 1))
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
                }
            }
        }
    }
    public override void AddGrade(string grade)
    {
        if (grade == "1" || grade == "1+" || grade == "2-" || grade == "2" || grade == "2+" || grade == "3-" || grade == "3" || grade == "3+"
        || grade == "4-" || grade == "4" || grade == "4+" || grade == "5-" || grade == "5" || grade == "5+" || grade == "6-" || grade == "6")
        {
            switch (grade)
            {
                case "1":
                    AddGrade(1.0);
                    break;

                case "1+":
                    AddGrade(1.5);
                    break;

                case "2-":
                    AddGrade(1.75);
                    break;

                case "2":
                    AddGrade(2.0);
                    break;

                case "2+":
                    AddGrade(2.5);
                    break;

                case "3-":
                    AddGrade(2.75);
                    break;

                case "3":
                    AddGrade(3.0);
                    break;

                case "3+":
                    AddGrade(3.5);
                    break;

                case "4-":
                    AddGrade(3.75);
                    break;

                case "4":
                    AddGrade(4.0);
                    break;

                case "4+":
                    AddGrade(4.5);
                    break;

                case "5-":
                    AddGrade(4.75);
                    break;

                case "5":
                    AddGrade(5.0);
                    break;

                case "5+":
                    AddGrade(5.5);
                    break;

                case "6-":
                    AddGrade(5.75);
                    break;

                case "6":
                    AddGrade(6.0);
                    break;

                default:
                    AddGrade(0.0);
                    break;
            }
        }
        else
        {
            throw new ArgumentException($"Invalid out of range {nameof(grade)}.");
        }
    }
    public override Statistics GetStatistics()
    {
        var result = new Statistics();
        using (var reader = File.OpenText(Name + "." + filename))
        {
            var line = reader.ReadLine();
            while (!string.IsNullOrWhiteSpace(line))
            {
                var number = double.Parse(line);
                result.Add(number);
                line = reader.ReadLine();
            }
        }
        return result;
    }
}