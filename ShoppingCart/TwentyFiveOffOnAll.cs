namespace ShoppingCart
{
    class DiscountInPercent : CartItem
    {
        private int percentage=0;
        public DiscountInPercent(int percent)
        {
            percentage = percent;
        }
        public override void Execute(ShoppingCart listOfItems)
        {
            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems.list[i];
                if (itm is ISaleable)
                {
                    var saleable = ((ISaleable)itm);
                    saleable.setCost(saleable.getCost() * (100.0 - percentage)/100);
                }
            }

            level++;
            base.Execute(listOfItems);
        }
    }
}
