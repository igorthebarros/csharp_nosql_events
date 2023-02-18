namespace EventBus
{
    public class TestIntegrationEvent
    {
        public int ProductId { get; private set; }
        public decimal OldPrice { get; private set; }
        public decimal NewPrice { get; private set; }

        public TestIntegrationEvent(int productId, decimal oldPrice, decimal newPrice)
        {
            ProductId = productId;
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
}