using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    public class Product
    {
        private int id;
        private string name;
        private int price;
        private DateTime? orderDate;
        private string category;
        private string? shelf;
        private int count;
        private string? description;

        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [Range(0, 10000)]
        public int Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }
        [StringLength(20)]
        public string Category { get; set; }
        [StringLength(10)]
        public string Shelf { get; set; }
        [Range(0, 10000)]
        public int Count { get; set; }

        public string? Description { get; set; }
    }
}
