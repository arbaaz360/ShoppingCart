namespace ShoppingCart
{
    class DiscountInPercent : AbstractProcessor
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
                if (itm is ISalable)
                {
                    var salableItm = ((ISalable)itm);
                    salableItm.setCost(salableItm.getCost() * (100.0 - percentage)/100);
                }
            }

            level++;
            base.Execute(listOfItems);
        }
    }
}
