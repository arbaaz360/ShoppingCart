namespace ShoppingCart
{
    class TenPercentOnNextItem : AbstractProcessor
    {
        public override void Execute(ShoppingCart listOfItems)
        {
            var counter = 0;
            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems.list[i];

                if (i > level && itm is ISalable)
                {
                    counter++;
                    if (counter == 1)
                    {
                        var salableItm = ((ISalable)itm);
                        salableItm.setCost(salableItm.getCost() * 0.90);
                    }
                }
            }
            level++;
            base.Execute(listOfItems);
        }
    }
}
