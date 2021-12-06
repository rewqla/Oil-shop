using System.Collections.Generic;

namespace OilShop.Entities
{
    public class Oil
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
    }
}
