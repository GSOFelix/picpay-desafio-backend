using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class UsersRepository : IUsers
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();     
        }

        public async Task<Users> InsertAsync(Users users)
        {
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<Users?> SelectByIdAsync(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
