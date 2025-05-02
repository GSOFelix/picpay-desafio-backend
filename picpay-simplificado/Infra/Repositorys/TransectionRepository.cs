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
    public class TransectionRepository : ITransection
    {
        private readonly AppDbContext _context;

        public TransectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transactions>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task InsertAsync(Transactions transactions)
        {
            await _context.Transactions.AddAsync(transactions);

        }

        public async Task<Transactions?> SelectById(long id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
