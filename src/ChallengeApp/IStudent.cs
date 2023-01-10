public interface IStudent
{
    void AddGrade(double grade);
    void AddGrade(string grade);
    Statistics GetStatistics();
    string Name {get; set;}

    event GradeAddedDelegate GradeAdded;

}