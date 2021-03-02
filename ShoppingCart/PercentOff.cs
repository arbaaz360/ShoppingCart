namespace ShoppingCart
{
    public class PercentOff : CartItem
    {
        double percent { get; set; }
        public PercentOff(double percent)
        {
            this.percent = percent;
        }

        public double ApplyDiscount(double cost)
        {
            return cost * (100.0 - this.percent) / 100;
        }
    }
}
