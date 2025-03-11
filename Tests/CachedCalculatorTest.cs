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
    
    
    
    [Test]
        public void Add_CachesResult()
        {
            // Arrange
            var calc = new CachedCalculator();
            int a = 3, b = 4;
            
            // Act
            var result1 = calc.Add(a, b);
            int initialCacheCount = calc._cache.Count;
            var result2 = calc.Add(a, b);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(result2));
                Assert.That(calc._cache, Has.Count.EqualTo(initialCacheCount));
            });
        }
        
        [Test]
        public void Subtract_CachesResult()
        {
            // Arrange
            var calc = new CachedCalculator();
            int a = 10, b = 5;
            
            // Act
            var result1 = calc.Subtract(a, b);
            int initialCacheCount = calc._cache.Count;
            var result2 = calc.Subtract(a, b);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(result2));
                Assert.That(calc._cache, Has.Count.EqualTo(initialCacheCount));
            });
        }
        
        [Test]
        public void Multiply_CachesResult()
        {
            // Arrange
            var calc = new CachedCalculator();
            int a = 4, b = 6;
            
            // Act
            var result1 = calc.Multiply(a, b);
            int initialCacheCount = calc._cache.Count;
            var result2 = calc.Multiply(a, b);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(result2));
                Assert.That(calc._cache, Has.Count.EqualTo(initialCacheCount));
            });
        }
        
        [Test]
        public void Divide_CachesResult()
        {
            // Arrange
            var calc = new CachedCalculator();
            int a = 20, b = 4;
            
            // Act
            var result1 = calc.Divide(a, b);
            int initialCacheCount = calc._cache.Count;
            var result2 = calc.Divide(a, b);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(result2));
                Assert.That(calc._cache, Has.Count.EqualTo(initialCacheCount));
            });
        }
        
        [Test]
        public void Factorial_CachesResult()
        {
            // Arrange
            var calc = new CachedCalculator();
            int n = 5;
            
            // Act
            var result1 = calc.Factorial(n);
            int initialCacheCount = calc._cache.Count;
            var result2 = calc.Factorial(n);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(result2));
                Assert.That(calc._cache, Has.Count.EqualTo(initialCacheCount));
            });
        }
        
        [Test]
        public void IsPrime_CachesResult()
        {
            // Arrange
            var calc = new CachedCalculator();
            int candidate = 11;
            
            // Act
            var result1 = calc.IsPrime(candidate);
            int initialCacheCount = calc._cache.Count;
            var result2 = calc.IsPrime(candidate);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(result2));
                Assert.That(calc._cache, Has.Count.EqualTo(initialCacheCount));
            });
        }
    
    [Test]
    public void Divide_ByZero_ShouldThrowException_AndNotCacheResult()
    {
        // Arrange
        var calc = new CachedCalculator();
        int a = 5, b = 0;

        // Act
        TestDelegate act = () => calc.Divide(a, b);

        // Assert
        Assert.Throws<DivideByZeroException>(act);
        Assert.That(calc._cache, Has.Count.EqualTo(0));
    }

    [Test]
    public void Factorial_NegativeNumber_ShouldThrowException_AndNotCacheResult()
    {
        // Arrange
        var calc = new CachedCalculator();
        int n = -5;

        // Act
        TestDelegate act = () => calc.Factorial(n);

        // Assert
        Assert.Throws<ArgumentException>(act);
        Assert.That(calc._cache, Has.Count.EqualTo(0));
    }
    
    [Test]
    public void DifferentOperations_HaveSeparateCacheEntries()
    {
        // Arrange
        var calc = new CachedCalculator();
            
        // Act
        calc.Add(2, 3);
        calc.Subtract(5, 2);
        calc.Multiply(3, 3);
        calc.Divide(10, 2);
        calc.Factorial(4);
        calc.IsPrime(7);
            
        // Assert
        Assert.That(calc._cache, Has.Count.EqualTo(6));
    }
    
    [Test]
    public void GetCachedResult_ShouldReturnCachedValue()
    {
        // Arrange
        var calc = new CachedCalculator();
        int a = 5, b = 3;

        // Act
        var firstResult = calc.Add(a, b);
        int cacheSizeAfterFirstCall = calc._cache.Count;
        var cachedResult = calc.Add(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(cachedResult, Is.EqualTo(firstResult));
            Assert.That(calc._cache, Has.Count.EqualTo(cacheSizeAfterFirstCall));
        });
    }



}
