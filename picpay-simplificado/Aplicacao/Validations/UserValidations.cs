using Dominio.Entidades;
using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Validations
{
    public static  class UserValidations
    {
        public static void ValidateUser(Users sender, decimal ammount)
        {
            // Validar se ele é do tipo varejista
            if (sender.Type == UserType.MERCHANT)
                throw new InvalidOperationException("Usuários VAREJISTAS não pode realizar esse tipo de tranferência.");

            // Verificar se ele tem saldo para trasnferência
            if (sender.Wallet < ammount)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            }
        }
    }
}
