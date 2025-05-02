using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.UseCases.Interfaces;
using Aplicacao.Validations;
using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.UseCases
{
    public class TransectionUseCase : ITransectionUseCase
    {
        private readonly ITransection _repository;
        private readonly IUserUseCase _usersUseCase;
        private readonly IUnityOfWorks _unityOfWorks;
        private readonly IAuthorizeService _authorizeService;

        public TransectionUseCase(ITransection repository, IUserUseCase usersUseCase, IUnityOfWorks unityOfWorks,
            IAuthorizeService authorizeService)
        {
            _repository = repository;
            _usersUseCase = usersUseCase;
            _unityOfWorks = unityOfWorks;
            _authorizeService = authorizeService;
        }

        public async Task<Transactions> CreateTransection(TransectionDto transectionDto)
        {
            await _unityOfWorks.BeginTransection();

            try
            {
                // Selecionar os usuarios participnates
                var sender = await _usersUseCase.GetUserById(transectionDto.senderId);
                var reciver = await _usersUseCase.GetUserById(transectionDto.reciverId);

                // validar suas informaçoes
                UserValidations.ValidateUser(sender, transectionDto.ammount);

                //consulta serviço Autorizador
                if(! await _authorizeService.VerifyAuthorization())
                    throw new UnauthorizedAccessException("Transação não autorizada");

                //criar a transação e salva;
                var newTransection = new Transactions(transectionDto.ammount, sender.Id, reciver.Id, DateTime.Now);
                await _repository.InsertAsync(newTransection);

                //altera o saldo dos involvidos e salva
                sender.Wallet -= transectionDto.ammount;
                reciver.Wallet += transectionDto.ammount;

                await _unityOfWorks.SaveChangesAsync();
                await _unityOfWorks.CommitTransection();

                return newTransection;
            }
            catch
            {
                await _unityOfWorks.RollBackTransection();
                throw;
            }

        }

        public async Task<Transactions> SelectTransectionById(long id)
        {
            return await _repository.SelectById(id)
                ?? throw new KeyNotFoundException("Transação não foi encontrada");
        }

        public async Task<List<Transactions>> SelectAllTransactions()
        {
            var response =  await _repository.GetAllAsync();

            return response.ToList() ??
                throw new KeyNotFoundException($"Nehuma transação encontrada");
        }
    }
}
