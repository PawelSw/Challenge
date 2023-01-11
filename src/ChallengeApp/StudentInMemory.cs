public class StudentInMemory : StudentBase
{
    private List<double> grades;
    public StudentInMemory(string name) : base(name)
    {
        grades = new List<double>();
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
        {
            if (grade > 0 && grade <= 6)
            {
                grades.Add(grade);
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
    public override Statistics GetStatistics()
    {
        var result = new Statistics();
        for (var index = 0; index < grades.Count; index++)
        {
            result.Add(grades[index]);
        }
        return result;
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

                case "6-":
                    AddGrade(5.75);
                    break;

                case "6":
                    AddGrade(6.0);
                    break;

                case "5+":
                    AddGrade(5.5);
                    break;

                default:
                    AddGrade(0.0);
                    break;
            }
        }
        else
        {
            throw new ArgumentException($"Invalid out of range {nameof(grade)}. Only grades from 1 to 6 are allowed!\"");
        }
    }
}
