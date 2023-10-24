using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshopping.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        
        public string CartProductIds { get; set; }  

        public void AddProductById(int productId)
        {
            if (CartProductIds == null)
            {
                CartProductIds = "[]";  
            }

            var productIds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(CartProductIds);
            productIds.Add(productId);
            CartProductIds = Newtonsoft.Json.JsonConvert.SerializeObject(productIds);
        }
        public void ClearCart()
        {
            CartProductIds = "[]";
        }
    }
}