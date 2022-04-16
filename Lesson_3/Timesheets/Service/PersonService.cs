using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.Repository;


namespace Timesheets.Service
{
    public sealed class PersonService : IPersonService
    {
        private PersonRepository _repository;
        public List<Person> _printPerson;

        public PersonService()
        {
            _repository = new PersonRepository();
            _printPerson = new List<Person>();
        }

        public List<Person> GetPersons()
        {
            Console.WriteLine(_repository.Data);
            return _repository.Data;
        }

        public List<Person> GetPerson(int id)
        {
            foreach (Person i in _repository.Data)
            {
                if (i.Id == id)
                {
                    _printPerson.Clear();
                    _printPerson.Add(i);

                    return _printPerson;
                }
            }

            return null;
        }

        public List<Person> SearchPerson(string firstName)
        {
            foreach (Person i in _repository.Data)
            {
                if (i.FirstName == firstName)
                {
                    i.FirstName = firstName;

                    _printPerson.Clear();
                    _printPerson.Add(i);

                    return _printPerson;
                }
            }

            return null;
        }

        public List<Person> PrintPersons(int skip, int take)
        {
            _printPerson = _repository.Data;

            return _printPerson.GetRange(skip, take);
        }

        public void AddPerson(Person person)
        {
            _repository.Data.Add(person);
        }

        public void UpdatePerson(Person p)
        {
            foreach (Person i in _repository.Data)
            {
                if (i.Id == p.Id)
                {
                    i.FirstName = p.FirstName;
                    i.LastName = p.LastName;
                    i.Email = p.Email;
                    i.Company = p.Company;
                    i.Age = p.Age;

                }
            }
        }

        public void DeletePerson(int id)
        {
            foreach (Person i in _repository.Data.ToList())
            {
                if (id == i.Id)
                {
                    _repository.Remove(i);
                }
            }

        }

    }
}
