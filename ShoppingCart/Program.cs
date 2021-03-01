using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractProcessor> listOfItems = new List<AbstractProcessor>();
            int level = -1;
            listOfItems.Add(new SalableItem(10));
            listOfItems.Add(new FlatCouponOn2ndPostCard());
            listOfItems.Add(new TwentyFiveOffOnAll());
            listOfItems.Add(new TenPercentOnNextItem());
            listOfItems.Add(new SalableItem(10));

            AbstractProcessor def = new DefaultClass();
            var ptr = def;
            foreach (var p in listOfItems)
            {
                def.SetSuccessor(p);
                def = p;
            }
            
            ptr.Execute(listOfItems, level);

            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems[i];
                if (itm is ISalable)
                {
                       Console.WriteLine(((ISalable)itm).getCost());
                }
            }
            Console.ReadLine();
        }
    }


    public abstract class AbstractProcessor
    {
        public int level { get; set; }
        public virtual AbstractProcessor Successor { get; protected set; }

        public virtual void Execute(List<AbstractProcessor> listOfItems, int level)
        {
            if (Successor != null)
            {
                Successor.Execute(listOfItems, level++);
            }
        }

        public virtual void SetSuccessor(AbstractProcessor successor)
        {
            if (Successor != null)
            {
                Successor.SetSuccessor(successor);
            }
            else
            {
                this.Successor = successor;
            }
        }
    }

    class DefaultClass : AbstractProcessor
    {
        public override void Execute(List<AbstractProcessor> listOfItems, int level)
        {
            Console.WriteLine("Cart Initiated:level:" + level);
            level++;
            base.Execute(listOfItems, level);
            //calculate
        }
    }

    class SalableItem : AbstractProcessor, ISalable
    {
        public double Cost { get; set; }
        public bool isSalable { get; set; }
        public SalableItem(int cost)
        {
            this.setCost(cost);
        }
        public override void Execute(List<AbstractProcessor> listOfItems, int level)
        {
            Console.WriteLine("SalableItem:level:" + level);
            level++;
            base.Execute(listOfItems, level);
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

    class FlatCouponOn2ndPostCard : AbstractProcessor
    {
        public override void Execute(List<AbstractProcessor> listOfItems, int level)
        {
            Console.WriteLine("FlatCouponOn2ndPostCard:level:" + level);
            var counter = 0;
            for(int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems[i];
                if(itm is ISalable)
                {
                    counter++;
                    if(counter == 2)
                    {
                        ((ISalable)itm).setCost(((ISalable)itm).getCost() - 2);
                    }
                }
            }

            level++;
            base.Execute(listOfItems, level);
        }
    }

    class TwentyFiveOffOnAll : AbstractProcessor
    {
        public override void Execute(List<AbstractProcessor> listOfItems, int level)
        {
            Console.WriteLine("TwentyFiveOffOnAll:level:" + level);
            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems[i];
                if (itm is ISalable)
                {
                    var salableItm = ((ISalable)itm);
                    salableItm.setCost(salableItm.getCost() * 0.75);
                }
            }

            level++;
            base.Execute(listOfItems,level);
        }
    }

    class TenPercentOnNextItem : AbstractProcessor
    {
        public override void Execute(List<AbstractProcessor> listOfItems, int level)
        {
            Console.WriteLine("TenPercentOnNextItem:level:" + level);
            var counter = 0;
            for (int i = 0; i < listOfItems.Count; i++)
            {
                var itm = listOfItems[i];
                
                if (i>level && itm is ISalable)
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
            base.Execute(listOfItems, level);
        }
    }

    interface ISalable
    {
        double getCost();
        double setCost(double cost);
    }

    public class CartModel
    {
        List<AbstractProcessor> listOfItems = new List<AbstractProcessor>();
    }
}
