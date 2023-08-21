namespace WS.Basic.Webapi.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Product>? GetProducts { get; set; }

        public void Update(string title)
        {
            this.Title = title;
        }
    }
}