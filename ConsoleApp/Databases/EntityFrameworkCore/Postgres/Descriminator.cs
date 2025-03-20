using Microsoft.EntityFrameworkCore;

namespace LearnDotNetConsole.Databases.EntityFrameworkCore.Postgres;

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
    // Add this property to store the discriminator value
    public string PaymentType { get; private set; }
}

public class CreditCardPayment : Payment
{
    public string CardNumber { get; init; } = string.Empty;
}

public class PayoneerPayment : Payment
{
    public string PayoneerEmail { get; init; } = string.Empty;
}

public class PaymentService(PostgresDbContext context)
{
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

        context.Payments.Add(creditPayment);
        context.Payments.Add(payoneerPayment);
        context.SaveChanges();
    }

    public void GetPayments()
    {
        var allPayments = context.Payments.ToList();

        foreach (var payment in allPayments)
        {
            Console.WriteLine($"ID: {payment.Id}, Amount: {payment.Amount}, PaymentType: {payment.PaymentType}, Type: {payment.GetType().Name}");
        }
    }
}