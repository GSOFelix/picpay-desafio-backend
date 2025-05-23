using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUsers
    {
        Task<Users> InsertAsync(Users users);
        Task<List<Users>> GetAllAsync();
        Task<Users?> SelectByIdAsync(long id);
    }
}
