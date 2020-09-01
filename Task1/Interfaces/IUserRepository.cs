using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(string id);

        Task<IReadOnlyList<User>> GetListAsync();

        Task<User> CreateAsync(User user);

        Task Update(string id, User user);

        Task Delete(string id);

    }
}
