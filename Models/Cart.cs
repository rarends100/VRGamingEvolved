﻿namespace VRGamingEvolved.Models
{
    public class Cart
    {
        public List<CartLine> lineCollection { get; set; }

        public Cart()
        {
            lineCollection = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public virtual void RemoveLine(Product product) => lineCollection.RemoveAll(i => i.Product.ProductId == product.ProductId);

        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Sell * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;  //Missed this so there was no way to loop through the collection
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }



    }
}

