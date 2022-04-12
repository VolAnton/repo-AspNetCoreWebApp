using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Contract
    {
        private static int counterIdContracts = 0;
        private int _id;
        private string _name;
        private string _description;
        private Task _task;
        private TimeSpan _time;

        public Contract()
        {
            _id = counterIdContracts;
            counterIdContracts++;
        }

        public int Id { get => _id; }

        public string Name { get => _name; set => _name = value; }

        public string Description { get => _description; set => _description = value; }

        public Task Task { get => _task; set => _task = value; }

        public TimeSpan Time { get => _time; set => _time = value; }
    }
}
