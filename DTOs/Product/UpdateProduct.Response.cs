namespace RookiesEFC02.DTOs.Product
{
    public class UpdateProductResponse
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public int CategoryId { get; set; }
    }
}