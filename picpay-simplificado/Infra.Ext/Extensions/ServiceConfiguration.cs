using Aplicacao.Interfaces;
using Aplicacao.UseCases;
using Aplicacao.UseCases.Interfaces;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorys;
using Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infra.Ext.Extensions
{
    public static class ServiceConfiguration
    {

        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            // Adicionar o contexto de dados
            services.AddDbContext<AppDbContext>(op =>
                op.UseSqlite("Data Source=app.db"));

            // Injetar dependecias de repositorio
            services.AddScoped<IUsers, UsersRepository>();
            services.AddScoped<ITransection, TransectionRepository>();
            services.AddScoped<IUnityOfWorks, UnityOfWorks>();

            // Injetar dependencias de serviços
            services.AddHttpClient<IAuthorizeService, AuthorizeService>();

            // Injetar dependencia de Use Case
            services.AddScoped<IUserUseCase, UsersUseCase>();
            services.AddScoped<ITransectionUseCase, TransectionUseCase>();


            return services;
        }
    }
}
