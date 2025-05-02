using Aplicacao.Dtos;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.UseCases.Interfaces
{
    public interface ITransectionUseCase
    {
        Task<Transactions> CreateTransection(TransectionDto transectionDto);
        Task<Transactions> SelectTransectionById(long id);
        Task<List<Transactions>> SelectAllTransactions();
    }
}
