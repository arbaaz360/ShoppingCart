namespace ShoppingCart
{
    class SaleableItem : CartItem, ISaleable
    {
        public double Cost { get; set; }
        
        public SaleableItem(int cost)
        {
            this.isSaleable = true;
            this.setCost(cost);
        }
        public override void Execute(ShoppingCart listOfItems)
        {
            level++;
            base.Execute(listOfItems);
        }

        public double getCost()
        {
            return Cost;
        }
        public double setCost(double cost)
        {
            this.Cost = cost;
            return this.Cost;
        }
    }
}
