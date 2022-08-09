using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPISample.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private ITransactionService _transactionservice;

        public TransactionsController(ITransactionService transactionservice)
        {
            _transactionservice = transactionservice;
        }

        [HttpPost(Name = nameof(AddTransactions))]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddTransactions(IEnumerable<Transaction> transactions)
        {
            await _transactionservice.AddTransactionsAsync(transactions);

            return Ok();
        }
    }
}
