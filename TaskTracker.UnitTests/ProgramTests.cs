namespace TaskTracker.UnitTests;

public class ProgramTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        int a = 5;
        int b = 5;

        // Act
        int result = a + b;

        // Assert
        Assert.Equal(10, result);
    }
}
