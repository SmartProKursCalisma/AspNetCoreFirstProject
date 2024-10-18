namespace AspNetCoreFirstProject.RequestTools.ProductQueryParameters
{
    public class RequestParameters
    {
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = decimal.MaxValue;
        public string IsActive { get; set; }
    }
}
