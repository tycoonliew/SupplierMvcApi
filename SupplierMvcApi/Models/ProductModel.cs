namespace SupplierMvcApi.Models
{
    public class ProductModel : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public bool Availability { get; set; }
        public SupplierModel Supplier { get; set; } // Many to one
    }
}