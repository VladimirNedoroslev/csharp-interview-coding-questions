namespace Refactoring.Examples;

public enum PaymentMethod
{
    Cash = 1,
    CreditCard = 2,
    DebitCard = 3
}

public sealed record Payment(PaymentMethod PaymentMethod);

public interface IPaymentService
{
    public void Pay(Payment payment);
}

public sealed class PaymentService : IPaymentService
{
    public void Pay(Payment payment)
    {
        // Code

        if (payment.PaymentMethod == PaymentMethod.Cash)
        {
            // Code
        }
        else if (payment.PaymentMethod == PaymentMethod.CreditCard)
        {
            // Code
        }
        else if (payment.PaymentMethod == PaymentMethod.DebitCard)
        {
            // Code
        }

        // Code
    }
}