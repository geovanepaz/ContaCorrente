using Core.Entities.Sql;
using Core.Interfaces.Repositories.Dapper;
using Core.Interfaces.Repositories.Sql;
using Infra.Contexts;
using Infra.Repositories.Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories.Sql
{
    public class ExtratoRepository : Repository<Extrato>, IExtratoRepository
    {
        private readonly ISqlHelper _sqlHelper;
        public ExtratoRepository(IWarrenContext context, IConfiguration configuration) : base(context)
        {
            _sqlHelper = new SqlHelper(configuration, "Warren");
        }

        public async Task<List<Extrato>> BuscarAsync(string agencia, string conta)
        {
            var query = 
                    $@"
                        SELECT 
		                    extrato.id,
		                    extrato.id_conta,
		                    extrato.data_referencia,
		                    extrato.tipo_operacao,
		                    extrato.saldo_atual,
		                    extrato.valor,
		                    extrato.id_pagamento
	                    FROM 
		                    extrato AS extrato
	                    JOIN 
		                    conta As conta ON extrato.id_conta = conta.id
		                WHERE
			                conta.numero_agencia = {agencia}
		                AND 
			                conta.numero_conta = {conta}
                    ";

            return _sqlHelper.Query<Extrato>(query).ToList();
        }
    }
}