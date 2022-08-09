using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly DatabaseContext _databaseContext;

        public TransactionService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddTransactionsAsync(IEnumerable<Transaction> transactions)
        {
            try
            {
                foreach (var transaction in transactions)
                {
                    await _databaseContext.AddAsync(transaction);
                }

                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
