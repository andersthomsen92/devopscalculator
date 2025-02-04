using Calculator;


namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Add_ShouldCacheResults()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var firstCall = calc.Add(a, b);
        var secondCall = calc.Add(a, b);

        // Assert: Cache should return the same result on the second call
        Assert.That(firstCall, Is.EqualTo(secondCall));
    }

    [Test]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 5;
        var b = 3;

        // Act
        var result = calc.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Multiply_ShouldReturnCorrectProduct()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Divide_ShouldReturnCorrectQuotient()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 6;
        var b = 3;

        // Act
        var result = calc.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Factorial_ShouldReturnCorrectResult()
    {
        // Arrange
        var calc = new CachedCalculator();
        var n = 5;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void Factorial_ShouldCacheResults()
    {
        // Arrange
        var calc = new CachedCalculator();
        var n = 5;

        // Act
        var firstCall = calc.Factorial(n);
        var secondCall = calc.Factorial(n);

        // Assert: Cache should return the same result on the second call
        Assert.That(firstCall, Is.EqualTo(secondCall));
    }

    [Test]
    public void IsPrime_ShouldReturnTrueForPrimeNumbers()
    {
        // Arrange
        var calc = new CachedCalculator();

        // Act
        var result = calc.IsPrime(7);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrime_ShouldReturnFalseForNonPrimeNumbers()
    {
        // Arrange
        var calc = new CachedCalculator();

        // Act
        var result = calc.IsPrime(4);

        // Assert
        Assert.That(result, Is.False);
    }
}
