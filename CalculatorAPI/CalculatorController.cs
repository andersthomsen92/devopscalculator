using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculator _calculator;
    public CalculatorController(ICalculator calculator)
    {
        _calculator = calculator;
    }

    [HttpPost("{operation}")]
    public IActionResult Calculate(string operation, [FromBody] CalculationRequest request)
    {
        int result = operation switch
        {
            "add" => _calculator.Add(request.A, request.B ?? 0),
            "subtract" => _calculator.Subtract(request.A, request.B ?? 0),
            "multiply" => _calculator.Multiply(request.A, request.B ?? 0),
            "divide" => _calculator.Divide(request.A, request.B ?? 1),
            "factorial" => _calculator.Factorial(request.A),
            "isPrime" => _calculator.IsPrime(request.A) ? 1 : 0,
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