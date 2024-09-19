namespace machineTest_svc.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Rating Rating { get; set; }
        public BannerLabel BannerLabel { get; set; }
    }
}
