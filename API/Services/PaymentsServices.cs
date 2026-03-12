using API.Entities;
using Stripe;

namespace API.Services;

public class PaymentsServices(IConfiguration config)
{
    public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(Basket basket)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];

        var service = new PaymentIntentService();
        PaymentIntent intent;

        // Calculate subtotal
        var subtotal = basket.Items.Sum(x => x.Quantity * x.Product.Price);

        // Delivery fee
        var deliveryFee = subtotal > 1000 ? 0 : 500;

        // Stripe requires cents
        var totalAmount = (subtotal + deliveryFee) * 100;

        if (string.IsNullOrEmpty(basket.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = totalAmount,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };

            intent = await service.CreateAsync(options);
        }
        else
        {
            var options = new PaymentIntentUpdateOptions
            {
                Amount = totalAmount
            };

            intent = await service.UpdateAsync(basket.PaymentIntentId, options);
        }

        return intent;
    }
}