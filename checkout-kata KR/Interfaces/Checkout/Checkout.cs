namespace checkout_kata_KR.Interfaces.SKU;
    using checkout_kata_KR.Models.SKU;
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice(List<SKU> SKUs);
    }
}
