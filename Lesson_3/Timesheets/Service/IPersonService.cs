using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.Service
{
    public interface IPersonService
    {
        List<Person> GetPersons();

        List<Person> GetPerson(int id);

        List<Person> SearchPerson(string firstName);

        List<Person> PrintPersons(int skip, int take);

        void AddPerson(Person person);

        void UpdatePerson(Person person);

        void DeletePerson(int id);

    }
}
