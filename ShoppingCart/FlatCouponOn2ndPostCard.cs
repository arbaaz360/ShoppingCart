﻿namespace ShoppingCart
{
    class FlatCoupon : AbstractProcessor
    {
        private int position;
        public FlatCoupon(int pos)
        {
            this.position = pos;
        }
        public override void Execute(ShoppingCart listOfItems)
        {
            var counter = 0;
            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems.list[i];
                if (itm is ISalable)
                {
                    counter++;
                    if (counter == 2)
                    {
                        var salableItm = ((ISalable)itm);
                        salableItm.setCost(salableItm.getCost() - this.position);
                    }
                }
            }

            level++;
            base.Execute(listOfItems);
        }
    }
}
