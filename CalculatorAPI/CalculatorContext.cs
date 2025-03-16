public class CalculatorContext : DbContext
{
    public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options) { }

    public DbSet<CalculationHistory> History { get; set; }
}