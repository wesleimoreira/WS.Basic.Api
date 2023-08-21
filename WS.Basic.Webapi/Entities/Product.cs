namespace WS.Basic.Webapi.Entities
{
    public class Product
    {

        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsProductActive { get; set; }

        public int CategoryID { get; set; }
        public Category? GetCategory { get; set; }

        public void Update(string name, int quantity, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            CategoryID = categoryId;
        }

        public void Delete(bool isProductActive)
        {
            this.IsProductActive = isProductActive;
        }
    }
}