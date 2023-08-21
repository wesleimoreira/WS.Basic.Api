
namespace WS.Basic.Webapi.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsProductActive { get; set; }
        public CategoryViewModel? GetCategory { get; set; }
    }
}