namespace Destek.Domain.Entities
{
    public class TicketTransactionFile : CommonFile
    {
        public ICollection<TicketTransaction> TicketTransactions { get; set; }
    }
}
