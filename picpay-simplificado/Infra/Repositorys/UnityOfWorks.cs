using Dominio.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class UnityOfWorks : IUnityOfWorks
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnityOfWorks(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransection()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransection()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollBackTransection()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
