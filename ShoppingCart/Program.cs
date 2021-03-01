using System;

namespace ShoppingCart
{
    class Program
    {


        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            //Case 1
            //listOfItems.Add(new TenPercentOnNextItem());
            //listOfItems.Add(new SalableItem(10));
            //listOfItems.Add(new SalableItem(20));

            //Case 2
            //listOfItems.Add(new SalableItem(10));
            //listOfItems.Add(new TenPercentOnNextItem());
            //listOfItems.Add(new SalableItem(20));

            //Case 3
            cart.Add(new SalableItem(10));
            cart.Add(new FlatCoupon(2));
            cart.Add(new DiscountInPercent(25));
            cart.Add(new TenPercentOnNextItem());
            cart.Add(new SalableItem(10));


            Console.WriteLine("Answer:"+cart.getTotal());
            Console.ReadLine();
        }
    }
}
