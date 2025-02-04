using Calculator;
using NUnit.Framework;

namespace Tests;

public class SimpleCalculatorTest
{
    [Test]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        // Arrange
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
        var a = 6;
        var b = 3;

        // Act
        var result = calc.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Divide_ShouldThrowDivideByZeroException()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 6;
        var b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => calc.Divide(a, b));
    }

    [Test]
    public void Factorial_ShouldReturnCorrectResult()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 5;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void Factorial_ShouldThrowArgumentExceptionForNegativeNumbers()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => calc.Factorial(n));
    }

    [Test]
    public void IsPrime_ShouldReturnTrueForPrimeNumbers()
    {
        // Arrange
        var calc = new SimpleCalculator();

        // Act
        var result = calc.IsPrime(7);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrime_ShouldReturnFalseForNonPrimeNumbers()
    {
        // Arrange
        var calc = new SimpleCalculator();

        // Act
        var result = calc.IsPrime(4);

        // Assert
        Assert.That(result, Is.False);
    }
}
