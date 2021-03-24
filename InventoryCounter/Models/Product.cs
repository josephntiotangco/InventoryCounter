using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryCounter.Models
{
    public class Product
    {
        public string description { get; set; }
        public string barcode { get; set; }
        public int system_quantity { get; set; }
        public int actual_quantity { get; set; }
    }
}
