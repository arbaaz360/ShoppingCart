namespace ShoppingCart
{
    public abstract class AbstractProcessor
    {
        public virtual AbstractProcessor Successor { get; protected set; }

        public virtual void Execute(ShoppingCart listOfItems)
        {
            if (Successor != null)
            {
                Successor.Execute(listOfItems);
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
}
