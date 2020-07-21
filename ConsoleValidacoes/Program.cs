using ConsoleValidacoes.Entidades;
using ConsoleValidacoes.Enum;
using ConsoleValidacoes.Validacao;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleValidacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemVenda itemUm = new ItemVenda()
            {
                Descricao = "Cabo USB 2.5m",
                Preco = 35,
                Quantidade = 1
            };

            ItemVenda itemDois = new ItemVenda()
            {
                Descricao = "",
                Preco = 0,
                Quantidade = 0
            };

            Venda venda = new Venda();
            venda.Data = DateTime.Today.AddDays(10);
            venda.Tipo = ETipoVenda.Padrao;
            venda.Total = 0;

            venda.Itens = new List<ItemVenda>();
            venda.Itens.Add(itemUm);

            VendaValidator validador = new VendaValidator();

            #region Lancar uma exception
            try
            {
                validador.ValidateAndThrow(venda); 
            }
            catch (ValidationException ex)
            {
                ex.Errors.ToList().ForEach(e => Console.WriteLine($"{e.ErrorMessage}"));
            }

            #endregion 

            #region Sem lancar uma exception
            ValidationResult resultado = validador.Validate(venda);
            if (resultado.IsValid)
            {
                Console.WriteLine("Venda efetuada com sucesso");
            }
            else
            {
                Console.WriteLine("Venda invalida");
                resultado.Errors.ToList().ForEach(e => Console.WriteLine($"{ e.ErrorMessage }"));
            }
            #endregion 

            Console.ReadKey();
        }
    }
}
