using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}