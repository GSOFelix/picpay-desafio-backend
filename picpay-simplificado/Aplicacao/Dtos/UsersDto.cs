using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aplicacao.Dtos
{
    public record UsersDto(
        long? id,
        string name,
        string lastName,
        string document,
        string email,
        decimal wallet,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        UserType type,
        string passWord
        );
}
