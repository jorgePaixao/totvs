using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotvsPDV.Models
{
    public partial class RegistroCaixa
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public decimal Dinheiro { get; set; }
        public decimal Troco { get; set; }
       
        [NotMapped]
        public List<String> TrocoDetalhado { get; set; }


        public RegistroCaixa()
        {
            TrocoDetalhado = new List<string>();
        }


        public void CalculaTroco()
        {
            Troco = Dinheiro - Valor;

            if (Troco > 0)
            {
                decimal valorRestante;
                valorRestante = CalcularCedulas(Troco);

                if (valorRestante > 0)
                {
                    CalcularMoedas(valorRestante);
                }

            }
            else if(Troco < 0)
            {
                throw new Exception("Erro,valor entregue menor do que o valor total do(s) produto(s).");
            }


        }

        private decimal CalcularMoedas(decimal valor)
        {

            List<decimal> moedas = new List<decimal>() { 0.5m, 0.1m, 0.05m, 0.01m };

            decimal valorAuxiliar = valor;

            foreach (decimal item in moedas)
            {
                if (valorAuxiliar >= item)
                {
                    int numero;
                    numero = Convert.ToInt32(Math.Truncate(valorAuxiliar / item));
                    valorAuxiliar = valorAuxiliar % item;
                    TrocoDetalhado.Add(String.Format("{0} de {1} centavos", numero, item * 100));
                }
                else if (valorAuxiliar == 0)
                {
                    break;
                }

            }

            return valorAuxiliar;
        }


        private decimal CalcularCedulas(decimal valor)
        {
            List<decimal> cedulas = new List<decimal>() { 100, 50, 20, 10 };


            decimal valorAuxiliar = valor;

            foreach (decimal item in cedulas)
            {
                if (valorAuxiliar >= item)
                {
                    int numero = Convert.ToInt32(Math.Truncate(valorAuxiliar / item));
                    valorAuxiliar = valorAuxiliar % item;
                    TrocoDetalhado.Add(String.Format("{0} de {1} reais", numero, item));
                }
                else if (valorAuxiliar == 0)
                {
                    break;
                }
            }
            

            return valorAuxiliar;
        }

    }

}
