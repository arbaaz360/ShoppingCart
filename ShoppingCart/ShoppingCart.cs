using System.Collections.Generic;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        public List<CartItem> list = new List<CartItem>();
        public int Count { get; set; } = 0;
        public void Add(CartItem processor)
        {
            processor.level = Count++;
            list.Add(processor);
        }
        public double getTotal()
        {
            AbstractProcessor def = new DefaultClass();
            var ptr = def;
            foreach (var p in list)
            {
                def.SetSuccessor(p);
                def = p;
            }

            ptr.Execute(this);

            var total = 0.0;
            for (int i = 0; i < list.Count; i++)
            {
                var itm = this.list[i];
                if (itm.isSaleable)
                {
                    total += ((ISaleable)itm).getCost();

                }
            }
            return total;
        }
    }
}
