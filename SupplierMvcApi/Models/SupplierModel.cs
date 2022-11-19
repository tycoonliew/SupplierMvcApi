namespace SupplierMvcApi.Models
{
    public class SupplierModel : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductModel[] Products { get; set; } // One to many relationship
    }
}