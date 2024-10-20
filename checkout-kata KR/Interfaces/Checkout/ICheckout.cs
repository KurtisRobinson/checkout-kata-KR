namespace checkout_kata_KR.Interfaces.SKU;
using checkout_kata_KR.Models.SKU;
public interface ICheckout
    {
        void Scan(string item);
        decimal GetTotalPrice(List<Reciept> reciept);
    }