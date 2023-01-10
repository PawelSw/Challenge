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
    private void AddAndCheckEvent(double grade)
    {
        this.grades.Add(grade);
        if (GradeAdded != null && (grade <= 3 && grade >= 1))
        {
            GradeAdded(this, new EventArgs());
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
                    AddAndCheckEvent(1.0);
                    break;

                case "1+":
                    AddAndCheckEvent(1.5);
                    break;

                case "2-":
                    AddAndCheckEvent(1.75);
                    break;

                case "2":
                    AddAndCheckEvent(2.0);
                    break;

                case "2+":
                    AddAndCheckEvent(2.5);
                    break;

                case "3-":
                    AddAndCheckEvent(2.75);
                    break;

                case "3":
                    AddAndCheckEvent(3.0);
                    break;

                case "3+":
                    AddAndCheckEvent(3.5);
                    break;

                case "4-":
                    AddAndCheckEvent(3.75);
                    break;

                case "4":
                    AddAndCheckEvent(4.0);
                    break;

                case "4+":
                    AddAndCheckEvent(4.5);
                    break;

                case "5-":
                    AddAndCheckEvent(4.75);
                    break;

                case "5":
                    AddAndCheckEvent(5.0);
                    break;

                case "6-":
                    AddAndCheckEvent(5.75);
                    break;

                case "6":
                    AddAndCheckEvent(6.0);
                    break;

                case "5+":
                    AddAndCheckEvent(5.5);
                    break;

                default:
                    this.grades.Add(0.00);
                    break;
            }
        }
        else
        {
            throw new ArgumentException($"Invalid out of range {nameof(grade)}.");
        }
    }
}
