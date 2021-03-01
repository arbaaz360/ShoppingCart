using System.Collections.Generic;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        public List<AbstractProcessor> list = new List<AbstractProcessor>();
        public int Count { get; set; } = 0;
        public void Add(AbstractProcessor processor)
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
                if (itm is ISalable)
                {
                    total += ((ISalable)itm).getCost();

                }
            }
            return total;
        }
    }
}
