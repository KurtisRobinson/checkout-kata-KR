namespace checkout_kata_KR.Interfaces.SKU
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
