using AutoMapper;
using Core.Entities.Sql;
using Core.ViewModels.ContaCorrente;

namespace App.AutoMappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Extrato, ExtratoResponse>()
            .ForMember(d => d.ValorOperacao, o => o.MapFrom(s => s.Valor))
            .ForMember(d => d.Saldo, o => o.MapFrom(s => s.SaldoAtual));
        }
    }
}