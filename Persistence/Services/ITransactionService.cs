using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public interface ITransactionService
    {
        Task AddTransactionsAsync(IEnumerable<Transaction> transactions);
    }
}
