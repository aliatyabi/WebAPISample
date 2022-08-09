using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace Persistence.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPeopleAsync();

        Task AddPeopleAsync(IEnumerable<Person> people);

        Task<IEnumerable<PersonTransactionsViewModel>> GetPeopleTransactions();
    }
}
