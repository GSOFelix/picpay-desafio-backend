using Aplicacao.Dtos;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.UseCases.Interfaces
{
    public interface IUserUseCase
    {
        Task<Users> GetUserById(long id);
        Task<List<Users>> GetAllUsers();
        Task<Users> SaveUser(UsersDto usersDto);
    }
}
