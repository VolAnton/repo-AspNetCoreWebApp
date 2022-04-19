using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{

    [Table("Person", Schema = "Test")]
    public sealed class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public string Comment { get; internal set; }

    }
}
