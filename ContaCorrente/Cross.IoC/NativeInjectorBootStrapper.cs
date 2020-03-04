using App.Interfaces;
using App.Services;
using AutoMapper;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories.Dapper;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using Core.Providers;
using Core.Services;
using Core.Validations.ViewModels.ContaCorrente;
using Core.ViewModels.ContaCorrente;
using FluentValidation;
using Infra.Contexts;
using Infra.Repositories.Dapper;
using Infra.Repositories.Sql;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cross.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Dependências Microsoft
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Aplicação
                      services.AddTransient<IExtratoAppService, ExtratoAppService>();
            services.AddTransient<IResgateSaldoAppService, ResgateSaldoAppService>();
            services.AddTransient<IDepositoAppService, DepositoAppService>();
            services.AddTransient<IPagamentoAppService, PagamentoAppService>();
            services.AddTransient<IRendimentoAppService, RendimentoAppService>();

            services.AddScoped<IMapper>(o => new Mapper(o.GetRequiredService<IConfigurationProvider>(), o.GetService));

            // Validação        
            services.AddScoped<IValidator<ResgateRequest>, ResgateValidator>();
            services.AddScoped<IValidator<DepositoRequest>, DepositoValidator>();
            services.AddScoped<IValidator<PagamentoRequest>, PagamentoValidator>();
            services.AddScoped<IValidator<RendimentoRequest>, RendimentoValidator>();

            // Domínio
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IResgateSaldoService, ResgateSaldoService>();
            services.AddTransient<IDepositarService, DepositarService>();
            services.AddTransient<IPagamentoService, PagamentoService>();
            services.AddTransient<IExtratoService, ExtratoService>();
            services.AddTransient<IRendimentoService, RendimentoService>();

            services.AddTransient<IExcecaoService, ExcecaoService>();

            // Infra - Contextos, Helpers
            services.AddTransient<IWarrenContext, WarrenContext>();
            services.AddTransient<IWarrenLogContext, WarrenLogContext>();

            services.AddTransient<ISqlHelper, SqlHelper>();

            // Infra - Repositório Sql
            services.AddTransient<IExtratoRepository, ExtratoRepository>();
            services.AddTransient<IContaRepository, ContaoRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IComprovantePagamentoRepository, ComprovantePagamentoRepository>();

            // Infra - Repositório NoSql

            // Provider
            services.AddSingleton(typeof(IProvider<>), typeof(Provider<>));
        }
    }
}