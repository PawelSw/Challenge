namespace Challenge.Tests;
public class EmployeeTests
{
    [Fact]
    public void Test1()
    {
       //arrange
       var emp = new StudentInMemory("Paweł");
        emp.AddGrade(1.0);
        emp.AddGrade(2.0);
        emp.AddGrade(3.0);

       //act
        var result = emp.GetStatistics();
       

       //assert
        Assert.Equal(2.0, result.Average,2);
        Assert.Equal(1.0, result.Low);
        Assert.Equal(3.0, result.High);
    }
}