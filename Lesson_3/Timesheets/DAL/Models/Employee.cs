using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Employee
    {
        private int _id;
        private string _name;
        private TimeSpan _time;

        public int Id { get => _id; set => _id = value; }

        public string Name { get => _name; set => _name = value; }

        public TimeSpan Time { get => _time; set => _time = value; }
    }
}
