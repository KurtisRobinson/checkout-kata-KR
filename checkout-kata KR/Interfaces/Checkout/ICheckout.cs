namespace checkout_kata_KR.Interfaces.SKU;
using checkout_kata_KR.Models.SKU;
public interface ICheckout
    {
        List<string> Scan(List<string> checkoutList);
        decimal GetTotalPrice(List<Reciept> reciept);
    }