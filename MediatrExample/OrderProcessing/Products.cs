using System.Collections.Generic;

namespace MediatrExample.OrderProcessing
{
    public class Products
    {
        private readonly Dictionary<int, string> _products = new Dictionary<int, string>
        {
            {1, "Assisin's Creed: Syndicate"},
            {2, "Dr Who Season 8"},
            {3, "iPhone Watch"},
            {4, "Good Eats Box Set"},
        }; 

        public string Get(int productId)
        {
            return _products[productId];
        }
    }
}