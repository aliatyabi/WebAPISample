using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        
        public int TransactionId { get; set; }

        public int PersonId { get; set; }

        public string? TransactionDate { get; set; }

        public long Price { get; set; }
    }
}
