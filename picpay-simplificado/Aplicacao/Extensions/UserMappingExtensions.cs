using Aplicacao.Dtos;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Extensions
{
    public static class UserMappingExtensions
    {
        public static Users ToUser(this UsersDto dto)
        {
            return new Users(
                dto.name,
                dto.lastName,
                dto.document,
                dto.email,
                dto.wallet,
                dto.type,
                dto.passWord);
        }

        public static UsersDto ToUserDto(this Users users)
        {
            return new UsersDto
            (
                id : users.Id,
                name : users.Name,
                lastName : users.LastName,
                document : users.Document,
                email: users.Email,
                wallet: users.Wallet,
                type: users.Type,
                passWord : ""
            );
        }


    }
}
