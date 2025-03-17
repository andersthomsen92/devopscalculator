using Microsoft.AspNetCore.Mvc;
using Calculator;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculator _simpleCalculator;
    private readonly ICalculator _cachedCalculator;
    private readonly CalculatorContext _context;

    public CalculatorController(SimpleCalculator simpleCalculator, CachedCalculator cachedCalculator, CalculatorContext context)
    {
        _simpleCalculator = simpleCalculator;
        _cachedCalculator = cachedCalculator;
        _context = context;
    }

    [HttpPost("{calculatorType}/{operation}")]
    public IActionResult Calculate(string calculatorType, string operation, [FromBody] CalculationRequest request)
    {
        // Select the appropriate calculator based on the type
        ICalculator calculator = calculatorType switch
        {
            "simple" => _simpleCalculator,
            "cached" => _cachedCalculator,
            _ => throw new ArgumentException("Invalid calculator type")
        };

        // Perform the operation
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

        /*// Create the calculation text string
        string calculationText = operation switch
        {
            "add" => $"{request.A} + {request.B ?? 0} = {result}",
            "subtract" => $"{request.A} - {request.B ?? 0} = {result}",
            "multiply" => $"{request.A} * {request.B ?? 0} = {result}",
            "divide" => $"{request.A} / {request.B ?? 1} = {result}",
            "factorial" => $"{request.A}! = {result}",
            "isPrime" => $"{request.A} is prime? {result}",
            _ => throw new ArgumentException("Invalid operation")
        };

        // Save the calculation to the database
        var history = new History
        {
            Text = calculationText,
            CreatedAt = DateTime.UtcNow
        };
        _context.History.Add(history);
        _context.SaveChanges();*/

        // Return the result as an API response
        return Ok(new { result });
    }
    
    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _context.History  
            .OrderByDescending(h => h.CreatedAt) 
            .Take(10)  // loading the last 10, can be adjusted
            .ToListAsync();
        return Ok(history);
    }
}

public class CalculationRequest
{
    public int A { get; set; }
    public int? B { get; set; }
}
