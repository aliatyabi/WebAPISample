using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Person
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        public string? Name { get; set; }

        public string? Family { get; set; }
    }
}
