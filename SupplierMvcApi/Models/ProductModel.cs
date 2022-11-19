using System;

namespace SupplierMvcApi.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public bool Availability { get; set; }
        public int SupplierId { get; set; }
        public SupplierModel Supplier { get; set; } // Many to one
    }
}