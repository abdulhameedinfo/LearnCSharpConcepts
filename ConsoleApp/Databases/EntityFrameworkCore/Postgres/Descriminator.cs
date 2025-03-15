using Microsoft.EntityFrameworkCore;

namespace LearnDotNetConsole.Databases.EntityFrameworkCore;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    public DbSet<Payment> Payments { get; set; } // Changed from Type to Payments

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>()
            .HasDiscriminator<string>("PaymentType")
            .HasValue<CreditCardPayment>("Credit")
            .HasValue<PayoneerPayment>("Payoneer");

        base.OnModelCreating(modelBuilder);
    }
}

public class Payment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public decimal Amount { get; init; }
    public DateTime CreatedAt { get; init; }
}

public class CreditCardPayment : Payment
{
    public string CardNumber { get; init; } = string.Empty;
}

public class PayoneerPayment : Payment
{
    public string PayoneerEmail { get; init; } = string.Empty;
}

public class PaymentService
{
    private readonly PostgresDbContext _context;

    public PaymentService(PostgresDbContext context)
    {
        _context = context;
    }

    public void AddPayments()
    {
        var creditPayment = new CreditCardPayment
        {
            Amount = 1000,
            CardNumber = "1234-5678-9876-5432",
            CreatedAt = DateTime.UtcNow
        };

        var payoneerPayment = new PayoneerPayment
        {
            Amount = 500,
            PayoneerEmail = "user@payoneer.com",
            CreatedAt = DateTime.UtcNow
        };

        _context.Payments.Add(creditPayment);
        _context.Payments.Add(payoneerPayment);
        _context.SaveChanges();
    }

    public void GetPayments()
    {
        var allPayments = _context.Payments.ToList();

        foreach (var payment in allPayments)
        {
            Console.WriteLine($"ID: {payment.Id}, Amount: {payment.Amount}, Type: {payment.GetType().Name}");
        }
    }
}