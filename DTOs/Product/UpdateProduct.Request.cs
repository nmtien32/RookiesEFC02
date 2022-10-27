namespace RookiesEFC02.DTOs.Product
{
    public class UpdateProductRequest
    {
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public int CategoryId { get; set; }
    }
}