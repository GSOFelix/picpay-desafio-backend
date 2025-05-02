using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ITransection
    {
        Task InsertAsync(Transactions transactions);

        Task<Transactions?> SelectById(long id);

        Task<List<Transactions>> GetAllAsync();
    }
}
