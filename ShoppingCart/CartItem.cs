namespace ShoppingCart
{
    public class CartItem: AbstractProcessor
    {
        public int level { get; set; }
        public bool isSaleable { get; set; } = false;
    }
}
