namespace ShoppingCart
{
    class DefaultClass : AbstractProcessor
    {
        public override void Execute(ShoppingCart listOfItems)
        {
            level++;
            base.Execute(listOfItems);
        }
    }
}
