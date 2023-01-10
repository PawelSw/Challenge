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
        using (var writer = File.AppendText(Name + "." + filename))
        {
            using (var writer2 = File.AppendText(Name + "." + audit))
            {
                if (grade == "1" || grade == "1+" || grade == "2-" || grade == "2" || grade == "2+" || grade == "3-" || grade == "3" || grade == "3+"
                || grade == "4-" || grade == "4" || grade == "4+" || grade == "5-" || grade == "5" || grade == "5+" || grade == "6-" || grade == "6")
                {
                    switch (grade)
                    {
                        case "1":
                            writer.WriteLine(1.0);
                            writer2.WriteLine(1.0 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "1+":
                            writer.WriteLine(1.5);
                            writer2.WriteLine(1.5 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "2-":
                            writer.WriteLine(1.75);
                            writer2.WriteLine(1.75 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "2":
                            writer.WriteLine(2.0);
                            writer2.WriteLine(2.0 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "2+":
                            writer.WriteLine(2.5);
                            writer2.WriteLine(2.5 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "3-":
                            writer.WriteLine(2.75);
                            writer2.WriteLine(2.75 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "3":
                            writer.WriteLine(3.0);
                            writer2.WriteLine(3.0 + " " + DateTime.UtcNow.ToString());
                            GradeAdded(this, new EventArgs());
                            break;

                        case "3+":
                            writer.WriteLine(3.5);
                            writer2.WriteLine(3.5 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "4-":
                            writer.WriteLine(3.75);
                            writer2.WriteLine(3.75 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "4":
                            writer.WriteLine(4.0);
                            writer2.WriteLine(4.0 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "4+":
                            writer.WriteLine(4.5);
                            writer2.WriteLine(4.5 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "5-":
                            writer.WriteLine(4.75);
                            writer2.WriteLine(4.75 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "5":
                            writer.WriteLine(5.0);
                            writer2.WriteLine(5.0 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "5+":
                            writer.WriteLine(5.5);
                            writer2.WriteLine(5.5 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "6-":
                            writer.WriteLine(5.75);
                            writer2.WriteLine(5.75 + " " + DateTime.UtcNow.ToString());
                            break;

                        case "6":
                            writer.WriteLine(6.0);
                            writer2.WriteLine(6.0 + " " + DateTime.UtcNow.ToString());
                            break;

                        default:
                            writer.WriteLine(0.0);
                            writer2.WriteLine(0.0 + " " + DateTime.UtcNow.ToString());
                            break;

                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid out of range {nameof(grade)}.");

                }
            }
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