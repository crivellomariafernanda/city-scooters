using Xunit;

public class SampleTests
{
    [Fact]
    public void PassingTest()
    {
        Assert.Equal(4, 2 + 2);
    }

    [Fact]
    public void PassingTest2()
    {
        Assert.NotEqual(5, 2 + 2);
    }
}
