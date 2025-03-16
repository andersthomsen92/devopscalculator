using Microsoft.EntityFrameworkCore;
using Calculator.Models;

public class CalculatorContext : DbContext
{
    public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options) { }

    public DbSet<History> History { get; set; }
}