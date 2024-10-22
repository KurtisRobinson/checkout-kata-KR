namespace checkout_kata_KR.Models.SKU
{
    public class SKU()
    {
       public string SkuName { get; set; }
       public decimal UnitPrice { get; set; }
       public string SpecialPrice { get; set; }
    }

    public class Reciept() 
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string SpecialPrice { get; set; }
    }
}
