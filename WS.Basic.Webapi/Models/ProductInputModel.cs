
namespace WS.Basic.Webapi.Models
{
    public class ProductInputModel
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public bool IsProductActive { get; set; }
    }
}