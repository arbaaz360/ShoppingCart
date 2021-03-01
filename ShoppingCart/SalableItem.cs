namespace ShoppingCart
{
    class SalableItem : AbstractProcessor, ISalable
    {
        public double Cost { get; set; }
        public bool isSalable { get; set; }
        public SalableItem(int cost)
        {
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
