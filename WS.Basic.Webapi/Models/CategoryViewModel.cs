
namespace WS.Basic.Webapi.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<ProductViewModel>? GetProducts { get; set; }
    }
}