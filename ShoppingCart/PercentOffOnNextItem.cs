namespace ShoppingCart
{
    class PercentOffOnNextItem : PercentOff
    {
        public PercentOffOnNextItem(double percent):base(percent)
        {
        }
        public override void Execute(ShoppingCart listOfItems)
        {
            var counter = 0;
            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems.list[i];

                if (i > level && itm is ISaleable)
                {
                    counter++;
                    if (counter == 1)
                    {
                        var saleable = ((ISaleable)itm);
                        saleable.setCost(ApplyDiscount(saleable.getCost()));
                    }
                }
            }
            level++;
            base.Execute(listOfItems);
        }
    }
}
