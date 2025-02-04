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
    
    [Test]
    public void Subtract_ShouldHandleNegativeResults()
    {
        var calc = new CachedCalculator();

        // Test negative result
        Assert.That(calc.Subtract(2, 3), Is.EqualTo(-1));
    }

    [Test]
    public void Multiply_ShouldHandleZero()
    {
        var calc = new CachedCalculator();

        // Test multiplication with zero
        Assert.That(calc.Multiply(0, 5), Is.EqualTo(0));
        Assert.That(calc.Multiply(5, 0), Is.EqualTo(0));
    }

    [Test]
    public void Divide_ShouldThrowDivideByZeroException()
    {
        var calc = new CachedCalculator();

        // Test division by zero
        Assert.Throws<DivideByZeroException>(() => calc.Divide(5, 0));
    }

    [Test]
    public void Divide_ShouldHandleNegativeNumbers()
    {
        var calc = new CachedCalculator();

        // Test negative result
        Assert.That(calc.Divide(-6, 3), Is.EqualTo(-2));
        Assert.That(calc.Divide(6, -3), Is.EqualTo(-2));
    }
    
    [Test]
    public void Add_ShouldCacheResultsForRepeatedCalls()
    {
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // First call
        var firstCall = calc.Add(a, b);
    
        // Second call (should return cached result)
        var secondCall = calc.Add(a, b);
    
        Assert.That(firstCall, Is.EqualTo(secondCall));
    }

    [Test]
    public void Subtract_ShouldCacheResultsForRepeatedCalls()
    {
        var calc = new CachedCalculator();
        var a = 5;
        var b = 3;

        // First call
        var firstCall = calc.Subtract(a, b);
    
        // Second call (should return cached result)
        var secondCall = calc.Subtract(a, b);
    
        Assert.That(firstCall, Is.EqualTo(secondCall));
    }


}
