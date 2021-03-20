using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public ICollection<ProductOptions> ProductOptions { get; set; } = new List<ProductOptions>();

        [JsonIgnore]
        public bool IsNew { get; }
    }

}