namespace PizzaShopApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public float? Price { get; set; }

        public string? Description { get; set; }
        public bool IsGlutenFree { get; set; }

        public bool? IsFeatured { get; set; }

    }
}
