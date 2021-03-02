namespace ShoppingCart
{
    class DefaultClass : CartItem
    {
        public override void Execute(ShoppingCart listOfItems)
        {
            level++;
            base.Execute(listOfItems);
        }
    }
}
