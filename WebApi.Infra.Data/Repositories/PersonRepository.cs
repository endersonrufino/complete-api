using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Infra.Data.Context;

namespace WebApi.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            await _db.AddAsync(person);
            await _db.SaveChangesAsync();

            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPeoplesAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}
