using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Models.ViewModels
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }
        public int InventoryValue { get; set; }
    }
}
