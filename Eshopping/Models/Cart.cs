using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshopping.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        
        // Autres propriétés de Cart

        public string CartProductIds { get; set; }  // Utilisé pour stocker la liste des ID de produits sous forme de chaîne JSON

        // Méthode pour ajouter un produit au panier
        public void AddProductById(int productId)
        {
            if (CartProductIds == null)
            {
                CartProductIds = "[]";  // Initialisez la chaîne JSON vide
            }

            var productIds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(CartProductIds);
            productIds.Add(productId);
            CartProductIds = Newtonsoft.Json.JsonConvert.SerializeObject(productIds);
        }
    }
}