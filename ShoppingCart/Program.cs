using System;

namespace ShoppingCart
{
    class Program
    {


        static void Main(string[] args)
        {
            ShoppingCart cart1 = new ShoppingCart();

            //Case 1
            cart1.Add(new PercentOffOnNextItem(10));
            cart1.Add(new SaleableItem(10));
            cart1.Add(new SaleableItem(20));
            Console.WriteLine("Cart 1 Total:" + cart1.getTotal());

            ShoppingCart cart2 = new ShoppingCart();
            //Case 2
            cart2.Add(new SaleableItem(10));
            cart2.Add(new PercentOffOnNextItem(10));
            cart2.Add(new SaleableItem(20));
            Console.WriteLine("Cart 2 Total:" + cart2.getTotal());

            ShoppingCart cart3 = new ShoppingCart();
            //Case 3
            cart3.Add(new SaleableItem(10));
            cart3.Add(new FlatCoupon(2));
            cart3.Add(new DiscountInPercent(25));
            cart3.Add(new PercentOffOnNextItem(10));
            cart3.Add(new SaleableItem(10));


            Console.WriteLine("Cart 3 Total:"+cart3.getTotal());
            Console.ReadLine();
        }
    }
}
