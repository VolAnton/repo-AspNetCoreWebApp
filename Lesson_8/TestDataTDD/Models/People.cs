using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDataTDD.DataBase;

namespace TestDataTDD.Models
{
    public class People : IPeople
    {
        private Repository _repository;

        public List<Person> _pagePeople;

        public People()
        {
            _repository = new Repository();
            _pagePeople=new List<Person>();


        }

        /// <summary>
        /// Получить человека по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Person> GetPerson(int id)
        {
            foreach (var i in _repository.Data)
            {
                if (i.Id==id)
                {
                    _pagePeople.Clear();
                    _pagePeople.Add(i);

                    return _pagePeople;
                }
            }
            return null;
        }


        /// <summary>
        /// Добавить человека
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public void AddPerson(Person person)
        {
            _repository.Data.Add(person);
        }

        /// <summary>
        /// Удалить человека
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeletePerson(int id)
        {
            foreach (var i in _repository.Data.ToList())
            {
                if (id==i.Id)
                {
                    _repository.Remove(i);
                }
            }

        }

        /// <summary>
        /// Получить всех людей
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPeople()
        {
            return _repository.Data;
        }

        /// <summary>
        /// Получение списка людей с пагинацией
        /// </summary>
        /// <param name="skip">Пропускать</param>
        /// <param name="take">Брать</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Person> PagePeople(int skip, int take)
        {
            _pagePeople = _repository.Data;

            return _pagePeople.GetRange(skip, take);
        }

        /// <summary>
        /// Поиск человека по имени
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Person> SearchPerson( string firstName)
        {
            foreach (var i in _repository.Data)
            {
                if (i.FirstName==firstName)
                {
                    i.FirstName = firstName;

                    _pagePeople.Clear();
                    _pagePeople.Add(i);

                    return _pagePeople;
                }
            }
            return null;
        }

        /// <summary>
        /// Обновление существующего человека в коллекции
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdatePerson(Person p)
        {
            foreach (var i in _repository.Data)
            {
                if (i.Id== p.Id)
                {
                    i.FirstName=p.FirstName;
                    i.LastName=p.LastName;
                    i.Email=p.Email;
                    i.Company=p.Company;
                    i.Age=p.Age;
                    
                }
            }
            
        }
    }
}
