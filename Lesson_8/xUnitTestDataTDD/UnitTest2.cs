using Moq;
using System;
using System.Collections.Generic;
using TestDataTDD.DataBase;
using TestDataTDD.Models;
using Xunit;

namespace xUnitTestDataTDD
{
    public class UnitTest2
    {
        [Fact]
        public void GetPeople_Test()
        {
            Mock<IPeople> people = new Mock<IPeople>();

            people.Setup(m => m.GetPeople()).Returns(new List<Person>()
            {
                new Person(){ Id = 1, Age =23},
                new Person(){ Id = 2, Age =38}
            });
        }
    }
}