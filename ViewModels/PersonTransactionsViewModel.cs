using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PersonTransactionsViewModel
    {
        public string? FullName { get; set; }

        public int PersonId { get; set; }

        public string? Date { get; set; }

        public long Price { get; set; }
    }
}
