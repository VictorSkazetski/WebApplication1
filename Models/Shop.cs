using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkTime { get; set; }
        public IList<ShopProduct> ShopProducts { get; set; }
    }
}
