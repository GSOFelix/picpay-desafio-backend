using Aplicacao.Dtos;
using Aplicacao.Extensions;
using Aplicacao.UseCases.Interfaces;
using Dominio.Entidades;
using Dominio.Enums;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.UseCases
{
    public class UsersUseCase : IUserUseCase
    {
        private readonly IUsers _repository;

        public UsersUseCase(IUsers repository)
        {
            _repository = repository;
        }

        public async Task<Users> GetUserById(long id)
        {
            if (id == 0)
            {
                throw new ArgumentException("ID do usuario nao pode ser 0");
            }

            return await _repository.SelectByIdAsync(id)
                ?? throw new KeyNotFoundException("Usuario não encontrado");
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Users> SaveUser(UsersDto usersDto)
        {
            var user = usersDto.ToUser();
            return await _repository.InsertAsync(user);
        }
    }
}
