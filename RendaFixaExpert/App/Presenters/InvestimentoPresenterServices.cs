using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using RendaFixaExpert.App.Presenters.Interfaces;
using RendaFixaExpert.Model;

namespace RendaFixaExpert.App.Presenters
{
    public class InvestimentoPresenterServices : ICalculosInvestimentos
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public InvestimentoPresenterServices()
        {
        }

        /// <summary>
        /// Metodo responsavel por retornar o acumulo do investimento a partir da taxa de rendimento
        /// </summary>
        /// <param name="valorInvestido">Valor investido</param>
        /// <param name="taxaRendimento">Taxa de rendimento</param>
        /// <returns>CalcularAcumuloTaxaRendimentoAsync</returns>
        public async Task<decimal> CalcularAcumuloTaxaRendimentoAsync(decimal valorInvestido, decimal taxaRendimento) => await Task.FromResult(valorInvestido * (1m + (taxaRendimento / 100m)));


        /// <summary>
        /// Metodo responsavel por calcular a rentabilidade entre dois valores.
        /// </summary>
        /// <param name="rentabilidadeRequest"></param>
        /// <returns>CalcularTaxaRentabilidadeAsync</returns>
        public async Task<List<Rentabilidade>> CalcularTaxaRentabilidadeAsync(Rentabilidade rentabilidadeRequest)
        {
            List<Rentabilidade> listaRentabilidade = new List<Rentabilidade>();
            var dias = rentabilidadeRequest.Dias;
            Rentabilidade? rentabilidade = null;

            if (dias > 0)
            {
                for (int i = 0; i < rentabilidadeRequest?.ListValorAportados?.Count; i++)
                {
                    if(i == 0) {
                        rentabilidade = new Rentabilidade
                        {
                            Dias = 1,
                            ValorAportado = rentabilidadeRequest.ListValorAportados[0],
                            RentabilidadePorDia = 0
                        };
                        listaRentabilidade.Add(rentabilidade);
                        continue;
                    }
                    var valorInicial = rentabilidadeRequest.ListValorAportados[i - 1];
                    var valorFinal = rentabilidadeRequest.ListValorAportados[i];
                    var valorAportado = valorFinal;
                    var dia = i+1;

                    rentabilidade = new Rentabilidade
                    {
                        Dias = dia++,
                        ValorAportado = valorAportado,
                        RentabilidadePorDia = ((valorFinal / valorInicial) - 1) * 100
                    };
                    listaRentabilidade.Add(rentabilidade);
                }
            }
            return await Task.FromResult(listaRentabilidade);
        }
    }
}
