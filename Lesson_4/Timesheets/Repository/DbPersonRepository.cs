using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DbContexts;

namespace Timesheets.Repository
{
    public sealed class IDbPersonRepository
    {
        private readonly PersonDbContext _context;

        public IDbPersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task Add(Person entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Person>> Get()
        {
            List<Person> res = await _context.Persons.Where(x => x.IsDeleted == false).ToListAsync();
            return res;
        }

        public async Task Update(Person entity)
        {
            Person ef = await _context.Persons.FirstOrDefaultAsync(x => x.Id == entity.Id);

            ef.FirstName = entity.FirstName;
            ef.LastName = entity.LastName;
            ef.Email = entity.Email;
            ef.IsDeleted = entity.IsDeleted;
            ef.Company = entity.Company;
            ef.Age = entity.Age;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Person entity = _context.Persons.Find(id);

            entity.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

    }
}