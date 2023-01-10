namespace Challenge.Tests;

public class TypeTests
{
    public delegate string WriteMessage (string message);

    int counter = 0;

    [Fact]
    public void WriteMessageDelegateCanPointToMethod()
    {
       WriteMessage del = ReturnMessage;
       del+=ReturnMessage;
       del+=ReturnMessage2;

       var result = del("Hello");
       //Assert.Equal("Hello",result);
       Assert.Equal(3,counter);
    }
     
    string ReturnMessage(string message)
    {
      counter++;
      return message;
    }
      string ReturnMessage2(string message)
    {
      counter++;
      return message.ToUpper();
    }
    [Fact]
    public void GetEmployeeReturnsDifferentObjects()
       {

       //arrange
      
       var emp1 = GetEmployee("Adam");
       var emp2 = GetEmployee("Tomek");
       Assert.NotSame(emp1,emp2);
       Assert.False(Object.ReferenceEquals(emp1,emp2));


       }
      [Fact]
       public void TwoVarsCanRefferenceTheSameObject()
       {
    
       var emp1 = GetEmployee("Adam");
       var emp2 = emp1;
       Assert.Same(emp1,emp2);
       Assert.True(Object.ReferenceEquals(emp1,emp2));
  
       }  

    
      private StudentInMemory GetEmployee(string name)
    {
        return new StudentInMemory(name);

    }

    private void SetName (StudentInMemory employee, string name)
    {

        employee.Name = name;
    }

       //assert
}
