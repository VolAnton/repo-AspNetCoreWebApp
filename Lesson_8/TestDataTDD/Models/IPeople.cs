using System;
using System.Collections.Generic;
using System.Text;
using TestDataTDD.DataBase;

namespace TestDataTDD.Models
{
    public interface IPeople
    {
        List<Person> GetPeople();

        List<Person> GetPerson(int id);

        List<Person> SearchPerson(string firstName);

        List<Person> PagePeople(int skip, int take);

        void AddPerson (Person person);

        void UpdatePerson (Person person);

        void DeletePerson (int id);
    }
}
