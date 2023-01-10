

namespace Challenge.Tests;

public class EmployeeTests
{
    [Fact]
    public void Test1()
    {
       //arrange
       var emp = new StudentInMemory("Paweł");
        emp.AddGrade(24.5);
        emp.AddGrade(35.8);
        emp.AddGrade(46.99);

       //act
        var result = emp.GetStatistics();
       

       //assert
        Assert.Equal(35.76, result.Average,2);
        Assert.Equal(24.5, result.Low);
        Assert.Equal(46.99, result.High);
    }
}