using Microsoft.AspNetCore.Mvc;
using Calculator;

[ApiController]
[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculator _simpleCalculator;
    private readonly ICalculator _cachedCalculator;

    public CalculatorController(SimpleCalculator simpleCalculator, CachedCalculator cachedCalculator)
    {
        _simpleCalculator = simpleCalculator;
        _cachedCalculator = cachedCalculator;
    }

    [HttpPost("{calculatorType}/{operation}")]
    public IActionResult Calculate(string calculatorType, string operation, [FromBody] CalculationRequest request)
    {
        ICalculator calculator = calculatorType switch
        {
            "simple" => _simpleCalculator,
            "cached" => _cachedCalculator,
            _ => throw new ArgumentException("Invalid calculator type")
        };

        int result = operation switch
        {
            "add" => calculator.Add(request.A, request.B ?? 0),
            "subtract" => calculator.Subtract(request.A, request.B ?? 0),
            "multiply" => calculator.Multiply(request.A, request.B ?? 0),
            "divide" => calculator.Divide(request.A, request.B ?? 1),
            "factorial" => calculator.Factorial(request.A),
            "isPrime" => calculator.IsPrime(request.A) ? 1 : 0,
            _ => throw new ArgumentException("Invalid operation")
        };

        return Ok(new { result });
    }
}


public class CalculationRequest
{
    public int A { get; set; }
    public int? B { get; set; }
}