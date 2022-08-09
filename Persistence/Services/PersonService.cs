using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Persistence.Services
{
    public class PersonService : IPersonService
    {
        private readonly DatabaseContext _databaseContext;

        public PersonService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<IEnumerable<Person>> GetPeopleAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddPeopleAsync(IEnumerable<Person> people)
        {
            try
            {
                foreach (var person in people)
                {
                    await _databaseContext.AddAsync(person);
                }

                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PersonTransactionsViewModel>> GetPeopleTransactions()
        {
            try
            {
                var transactionsJoinByPeople =
                        from p in _databaseContext.People
                        join t in _databaseContext.Transactions
                        on p.PersonId equals t.PersonId
                        select new
                        {
                            FullName = p.Name + " " + p.Family,
                            personId = t.PersonId,
                            Date = t.TransactionDate.Substring(0, 10),
                            price = t.Price
                        };

                var peopleTransactions = await transactionsJoinByPeople
                    .GroupBy(t => new { t.FullName, t.personId, t.Date })
                    .Select(t => new PersonTransactionsViewModel
                    {
                        FullName = t.Key.FullName,
                        PersonId = t.Key.personId,
                        Date = t.Key.Date,
                        Price = t.Sum(t => t.price)
                    }).ToListAsync();

                return peopleTransactions;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
