using ConsoleValidacoes.Enum;
using System;
using System.Collections.Generic;

namespace ConsoleValidacoes.Entidades
{
    public class Venda
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }

        public ETipoVenda Tipo { get; set; }
        
        public List<ItemVenda> Itens { get; set; }
    }
}
