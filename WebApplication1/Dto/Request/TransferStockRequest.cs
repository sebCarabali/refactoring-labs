namespace WebApplication1.Dto.Request
{
    public class TransferStockRequest
    {
        public required int ProductID { get; set; }
        public required int FromWarehouseId { get; set; }
        public required int ToWarehouseId { get; set; }
        public required int Quantity { get; set; }
    }
}
