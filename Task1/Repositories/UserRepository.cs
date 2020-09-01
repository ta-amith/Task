using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Data;
using Task1.Entities;
using Task1.Interfaces;

namespace Task1.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<User> GetByIdAsync(string id)
        {
            return await _user.Find(user => user.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IReadOnlyList<User>> GetListAsync()
        {
            return await _user.Find(contact => true).ToListAsync();
        }

        public async Task<User> CreateAsync(User contact)
        {
            await _user.InsertOneAsync(contact);
            return contact;
        }

        public async Task Update(string id, User user)
        {
            await _user.ReplaceOneAsync(user => user.Id == id, user);
        }

        public async Task Delete(string id)
        {
            await _user.DeleteOneAsync(user => user.Id == id);
        }
    }
}
